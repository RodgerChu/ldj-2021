using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    public Action OnPause;
    public Action OnContinue;

    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _toMenuButton;
    [SerializeField] private PausePopupAnimator _animator;

    private bool _shown = false;

    private void Start()
    {
        _continueButton.onClick.AddListener(Hide);
        _toMenuButton.onClick.AddListener(BackToMainMenu);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_shown)
                Hide();
            else
                Show();

            _shown = !_shown;
        }
    }

    private void Show()
    {
        OnPause?.Invoke();
        _animator.Show();
    }

    private void Hide()
    {
        OnContinue?.Invoke();
        _animator.Hide();
    }

    private void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
