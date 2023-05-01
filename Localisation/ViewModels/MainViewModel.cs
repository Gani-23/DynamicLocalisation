using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using Localisation.Loc;


namespace Localisation.ViewModels
{
    public class MainWindowViewModel
    {
        private Language _currentLanguage;
        private readonly Dictionary<string, CultureInfo> _supportedCultures;
        public MainWindowViewModel()
        {
            _supportedCultures = new Dictionary<string, CultureInfo>
            {
                { "hi-IN", new CultureInfo("hi-IN") },
                { "es-ES", new CultureInfo("es-ES") },
                { "kn-IN", new CultureInfo("kn-IN") },
                { "Te-IN", new CultureInfo("Te-IN") }
                
            };
            
            AvailableLanguages = new ObservableCollection<Language>
            {
                new Language("hi-IN", "हिंदी"),
                new Language("es-ES", "Español"),
                new Language("kn-IN", "ಕನ್ನಡ"),
                new Language("te-IN", "తెలుగు"),
            };
        }

        public ObservableCollection<Language> AvailableLanguages { get; }
        public Language CurrentLanguage
        {
            get => _currentLanguage;
            set
            {
                if (value == null || _currentLanguage == value)
                {
                    return;
                }

                _currentLanguage = value;
                var setlang = _currentLanguage.CultureName;
                LanguageService.Instance.ChangeLanguage(setlang);

            }
        }

        public class Language
        {
            public Language(string cultureName, string displayName)
            {
                CultureName = cultureName;
                DisplayName = displayName;
            }

            public string CultureName { get; }

            public string DisplayName { get; }

            public override string ToString()
            {
                return DisplayName;
            }
        }

    }
}

