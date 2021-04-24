using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LanguageChangeHandler : MonoBehaviour
{
    [SerializeField] private Button _russianLangButton;
    [SerializeField] private Button _engLangButton;

    [Space]
    [SerializeField] private Color _selectedLangColor = Color.red;
    [SerializeField] private Color _unselectedLangColor = Color.grey;

    [Space]
    [SerializeField] private string _russianLanguage = "Russian";
    [SerializeField] private string _englishLanguage = "English";

    [Inject] private LocalizationConfig _localizationConfig;

    private void Start()
    {
        _russianLangButton.onClick.AddListener(() => _localizationConfig.SetLanguage(_russianLanguage));
        _engLangButton.onClick.AddListener(() => _localizationConfig.SetLanguage(_englishLanguage));

        ColorSelectedLang();

        _localizationConfig.OnLocalizationChanged += ColorSelectedLang;
    }

    private void ColorSelectedLang()
    {
        if(_localizationConfig.CurrentLanguage == _russianLanguage)
        {
            _russianLangButton.GetComponent<Image>().color = _selectedLangColor;
            _engLangButton.GetComponent<Image>().color = _unselectedLangColor;
        }
        else
        {
            _russianLangButton.GetComponent<Image>().color = _unselectedLangColor;
            _engLangButton.GetComponent<Image>().color = _selectedLangColor;
        }
    }

    private void OnDestroy()
    {
        _localizationConfig.OnLocalizationChanged -= ColorSelectedLang;
    }
}
