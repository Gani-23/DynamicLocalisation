using System;
using Avalonia.Data;
using Avalonia.Markup.Xaml;

namespace Localisation.Loc;

public class LangExtension : MarkupExtension
{
    private readonly string _key;
    
    public LangExtension(string key)
    {
        _key = key;
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return new Binding($"[{_key}]")
        {
            Mode = BindingMode.OneWay,
            Source = LanguageService.Instance
        };
    }
}