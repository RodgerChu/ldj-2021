using System;
using UnityEngine;

public class LocalizationConfig
{
    public string CurrentLanguage => _currentLanguage;
    private string _currentLanguage;

    private string _languageKey = "LANGUAGE_KEY";
    private LocalizationData _data;

    public Action OnLocalizationChanged;

    public LocalizationConfig(LocalizationData data)
    {
        _data = data;
        LoadSelectedLanguage();
    }

    public void SetLanguage(string language)
    {
        if (_currentLanguage == language)
            return;

        _currentLanguage = language;
        OnLocalizationChanged?.Invoke();
        SaveSelectedLanguage();
    }

    public string GetLocalizedString(string key)
    {
        return _data.GetLocalizationFor(_currentLanguage, key);
    }

    private void SaveSelectedLanguage()
    {
        PlayerPrefs.SetString(_languageKey, _currentLanguage);
    }

    private void LoadSelectedLanguage()
    {
        _currentLanguage = PlayerPrefs.GetString(_languageKey, "Russian");
    }
}
