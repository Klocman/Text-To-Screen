/*
    Copyright (c) 2017 Marcin Szeniak (https://github.com/Klocman/)
    Apache License Version 2.0
*/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using Klocman.Extensions;
using Klocman.Tools;
using TextToScreen.Properties;

namespace TextToScreen.Misc
{
    public static class CultureConfigurator
    {
        private static IEnumerable<CultureInfo> _supportedLanguages;
        private static CultureInfo _enUsCulture;
        private static CultureInfo EnUsCulture => _enUsCulture ?? (_enUsCulture = CultureInfo.GetCultureInfo("en-US"));

        public static IEnumerable<CultureInfo> SupportedLanguages
        {
            get
            {
                return _supportedLanguages ?? (_supportedLanguages = new[]
                {
                    EnUsCulture,
                    CultureInfo.GetCultureInfo("en-GB"),
                    CultureInfo.GetCultureInfo("pl-PL")
                }.OrderBy(x => x.DisplayName).ToList().AsEnumerable());
            }
        }

        public static void SetupCulture()
        {
            var currentCulture = CultureInfo.CurrentCulture;

            var targetLocale = Ustawienia.Default.LanguageOverride;
            if (targetLocale.IsNotEmpty())
            {
                try
                {
                    currentCulture = SupportedLanguages.First(x => x.Name.Equals(targetLocale));
                }
                catch
                {
                    Ustawienia.Default.LanguageOverride = string.Empty;
                }
            }

            if (!currentCulture.Name.ContainsAny(SupportedLanguages.Select(x => x.Parent.Name),
                StringComparison.OrdinalIgnoreCase))
                currentCulture = EnUsCulture;

            ProcessTools.SetDefaultCulture(currentCulture);
            var thread = Thread.CurrentThread;
            thread.CurrentCulture = currentCulture;
            thread.CurrentUICulture = currentCulture;
        }
    }
}