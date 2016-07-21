using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace TextToScreen.Windows
{
    internal sealed partial class AboutBox : Form
    {
        private readonly Assembly _currentExecutingAssembly = Assembly.GetExecutingAssembly();

        public AboutBox()
        {
            InitializeComponent();
            Text += @" " + AssemblyTitle;
            labelProductName.Text += AssemblyProduct;
            labelVersion.Text += AssemblyVersion;
            labelCopyright.Text += AssemblyCopyright;
            labelCompanyName.Text += AssemblyCompany;
            textBoxDescription.Text = AssemblyDescription;
            labelCpu.Text += _currentExecutingAssembly.GetName().ProcessorArchitecture.ToString();
            okButton.Focus();
        }

        public string AssemblyCompany
        {
            get
            {
                var attributes = _currentExecutingAssembly.GetCustomAttributes(typeof (AssemblyCompanyAttribute), false);
                return attributes.Length == 0 ? string.Empty : ((AssemblyCompanyAttribute) attributes[0]).Company;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                var attributes = _currentExecutingAssembly.GetCustomAttributes(typeof (AssemblyCopyrightAttribute),
                    false);
                return attributes.Length == 0 ? string.Empty : ((AssemblyCopyrightAttribute) attributes[0]).Copyright;
            }
        }

        public string AssemblyDescription
        {
            get
            {
                var attributes = _currentExecutingAssembly.GetCustomAttributes(typeof (AssemblyDescriptionAttribute),
                    false);
                return attributes.Length == 0 ? string.Empty : ((AssemblyDescriptionAttribute) attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                var attributes = _currentExecutingAssembly.GetCustomAttributes(typeof (AssemblyProductAttribute), false);
                return attributes.Length == 0 ? string.Empty : ((AssemblyProductAttribute) attributes[0]).Product;
            }
        }

        public string AssemblyTitle
        {
            get
            {
                var attributes = _currentExecutingAssembly.GetCustomAttributes(typeof (AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    var titleAttribute = (AssemblyTitleAttribute) attributes[0];
                    if (titleAttribute.Title.Length == 0)
                    {
                        return titleAttribute.Title;
                    }
                }
                return Path.GetFileNameWithoutExtension(_currentExecutingAssembly.CodeBase);
            }
        }

        public string AssemblyVersion => _currentExecutingAssembly.GetName().Version.ToString();

        private void AboutBox_Shown(object sender, EventArgs e)
        {
            okButton.Focus();
        }
    }
}