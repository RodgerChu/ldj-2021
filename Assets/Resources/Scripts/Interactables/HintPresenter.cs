using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintPresenter : MonoBehaviour
{
    [SerializeField] private LocalizedTextWrapper _text;

    public void Show(string alias)
    {
        _text.SetLocalizationKey(alias);
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
