using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Klocman.Controls;
using Klocman.Extensions;
using Klocman.Localising;
using TextToScreen.Properties;
using TextToScreen.SongFile;

namespace TextToScreen.Controls
{
    public partial class FilterBox : UserControl
    {
        private static readonly LocalisedEnumWrapper[] FilteringOptions;

        static FilterBox()
        {
            FilteringOptions = Enum.GetValues(typeof (ComparisonMethod))
                .Cast<ComparisonMethod>().Select(x => new LocalisedEnumWrapper(x))
                .OrderBy(x => x.ToString())
                .ToArray();
        }

        public FilterBox()
        {
            InitializeComponent();

            groupFilterComboBox.Items.Add(Localisation.FileListView_GroupBox_ShowAll);
            groupFilterComboBox.Items.Add(string.Empty);

            comboBoxCompareMethod.Items.AddRange(FilteringOptions.Cast<object>().ToArray());
            comboBoxCompareMethod.SelectedIndex = comboBoxCompareMethod.Items.IndexOf(
                FilteringOptions.Single(x => (ComparisonMethod) x.TargetEnum == ComparisonMethod.Contains));
        }

        public bool SearchStringIsEmpty => string.IsNullOrEmpty(searchBox1.SearchString);

        public Control SearchBox => searchBox1;

        private ComparisonMethod SelectedComparisonMethod
            => (ComparisonMethod) ((LocalisedEnumWrapper) comboBoxCompareMethod.SelectedItem).TargetEnum;

        public void ClearSearchBox()
        {
            searchBox1.ClearSearchBox();
        }

        public void SetGroups(IEnumerable<SongFileEntry> entries)
        {
            groupFilterComboBox.SelectedIndex = 0;
            while (groupFilterComboBox.Items.Count > 2)
                groupFilterComboBox.Items.RemoveAt(2);

            var query = entries.GroupBy(x => x.Group)
                .Select(group => string.IsNullOrEmpty(group.Key) ? Localisation.DefaultGroupName : group.Key)
                .OrderBy(x => x);

            groupFilterComboBox.Items.AddRange(query.Cast<object>().ToArray());
        }

        public void FocusSearchbox()
        {
            searchBox1.FocusSearchBox();
        }

        private bool CheckGroupMatch(SongFileEntry entry)
        {
            if (groupFilterComboBox.SelectedIndex <= 1) return true;

            var filter = groupFilterComboBox.SelectedItem as string;
            if (filter == null || filter.Equals(Localisation.DefaultGroupName))
                filter = string.Empty;
            return entry.Group.Equals(filter, StringComparison.CurrentCulture);
        }

        /// <summary>
        ///     Test if the input matches this condition. Returns null if it is impossible to determine.
        /// </summary>
        public bool? TestEntry(SongFileEntry item)
        {
            if (!Enabled) return null;

            bool? result = null;

            if (!CheckGroupMatch(item))
            {
                result = false;
            }
            else
            {
                // Check the string. Skip checking if no search string is input
                var filterText = searchBox1.SearchString?.StripAccents();

                if (!string.IsNullOrEmpty(filterText))
                {
                    try
                    {
                        Func<string, bool> compFun;

                        // Select delegate to use for comparisons
                        switch (SelectedComparisonMethod)
                        {
                            case ComparisonMethod.Equals:
                                compFun = src => src.Equals(filterText, StringComparison.InvariantCultureIgnoreCase);
                                break;

                            case ComparisonMethod.Any:
                                compFun =
                                    src =>
                                        src.ContainsAny(
                                            filterText.Split((char[]) null, StringSplitOptions.RemoveEmptyEntries),
                                            StringComparison.InvariantCultureIgnoreCase);
                                break;

                            case ComparisonMethod.StartsWith:
                                compFun = src => src.StartsWith(filterText, StringComparison.InvariantCultureIgnoreCase);
                                break;

                            case ComparisonMethod.EndsWith:
                                compFun = src => src.EndsWith(filterText, StringComparison.InvariantCultureIgnoreCase);
                                break;

                            case ComparisonMethod.Contains:
                                compFun = src => src.Contains(filterText, StringComparison.InvariantCultureIgnoreCase);
                                break;

                            case ComparisonMethod.Regex:
                                compFun = src => Regex.IsMatch(src, filterText, RegexOptions.CultureInvariant);
                                break;

                            default:
                                throw new InvalidOperationException("Unknown FilterComparisonMethod");
                        }

                        result = compFun(item.Name.StripAccents()) || compFun(item.Comment.StripAccents()) ||
                                 (searchInsideFilesCheckBox.Checked && compFun(item.Contents.StripAccents()));
                    }
                    catch (InvalidOperationException)
                    {
                        throw;
                    }
                    catch
                    {
                        //result = null;
                    }
                }
            }

            if (!result.HasValue) return null;

            return checkBoxInvert.Checked ? !result.Value : result.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            searchBox1.ClearSearchBox();
        }

        private void groupFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (groupFilterComboBox.SelectedIndex == 1)
                groupFilterComboBox.SelectedIndex = 0;

            OnFilterChanged(sender, e);
        }

        public event EventHandler FilterChanged;

        private void OnFilterChanged(object sender, EventArgs eventArgs)
        {
            FilterChanged?.Invoke(sender, eventArgs);
        }

        private void searchBox1_SearchTextChanged(SearchBox arg1, EventArgs arg2)
        {
            OnFilterChanged(arg1, arg2);
        }
    }
}