using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class LocalizedTextWrapper : MonoBehaviour
{
    public TextMeshProUGUI InnetText;
    [SerializeField] private string _localizationKey;

    [Inject] private LocalizationConfig _localizationConfig;

    private void Awake()
    {
        _localizationConfig.OnLocalizationChanged += UpdateLocale;
    }

    private void Start()
    {
        UpdateLocale();
    }

    public void SetLocalizationKey(string key)
    {
        _localizationKey = key;
        UpdateLocale();
    }

    private void UpdateLocale()
    {
        InnetText.text = _localizationConfig.GetLocalizedString(_localizationKey);
    }

    private void OnDestroy()
    {
        _localizationConfig.OnLocalizationChanged -= UpdateLocale;
    }
}
