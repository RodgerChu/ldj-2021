using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreenAnimator : MonoBehaviour
{
    [SerializeField] private CanvasGroup _deathScreenCanvas;

    [Space]
    [SerializeField] private float _transitionDuration = 1f;

    public void Show()
    {
        _deathScreenCanvas.DOFade(1, _transitionDuration);
        SetCanvasActive(true);
    }

    public void Hide()
    {
        _deathScreenCanvas.DOFade(0, _transitionDuration);
        SetCanvasActive(false);
    }

    private void SetCanvasActive(bool active)
    {
        _deathScreenCanvas.interactable = active;
        _deathScreenCanvas.blocksRaycasts = active;
    }
}
