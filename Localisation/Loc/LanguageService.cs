using System.ComponentModel;
using System.Globalization;
using JetBrains.Annotations;
using Localisation.Resources;
using ReactiveUI;

namespace Localisation.Loc;

public class LanguageService : ReactiveObject, INotifyPropertyChanged
{
    static LanguageService()
    {
        Instance = new LanguageService();

        var value = Instance["GetEnv"];
    }

    public static LanguageService Instance { get; }

    public event PropertyChangedEventHandler PropertyChanged;
    
    [UsedImplicitly] 
    public string this[string key] => Strings.ResourceManager.GetString(key);

    public void ChangeLanguage(string language)
    {
        var currentCulture = new CultureInfo(language);

        CultureInfo.CurrentCulture =
            CultureInfo.CurrentUICulture =
                CultureInfo.DefaultThreadCurrentCulture =
                    CultureInfo.DefaultThreadCurrentUICulture = currentCulture;

        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs("Item"));
        }
    }

}