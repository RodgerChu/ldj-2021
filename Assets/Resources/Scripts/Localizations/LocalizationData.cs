using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationData : ScriptableObject
{
    public Dictionary<string, Dictionary<string, string>> LocalizationValues;

    public const string AssetPath = "Assets/Config/LocalizationData.asset";

    public string GetLocalizationFor(string language, string key)
    {
        if (LocalizationValues.ContainsKey(language))
        {
            var strings = LocalizationValues[language];
            if (strings.ContainsKey(key))
            {
                return strings[key];
            }
            else
            {
                Debug.LogError($"Localization data doesn't contain such key: {key}");
                return "no_such_key";
            }
        }
        else
        {
            Debug.LogError($"Localization data doesn't contain such language: {language}");
            return "no_such_language";
        }
    }
}
