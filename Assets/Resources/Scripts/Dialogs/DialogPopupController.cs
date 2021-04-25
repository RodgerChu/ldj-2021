using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogPopupController : MonoBehaviour
{
    [SerializeField] private DialogPopupPresenter _dialogPresenter;
    [SerializeField] private float _timeUntilCanSkeep = 1f;

    public Action OnDialogClosed;
    public Action OnDialogOpened;

    private DialogData _dialogData;

    public void StartDialog(DialogData dialogData)
    {
        _dialogData = dialogData;
        _dialogPresenter.SetSpeakers(_dialogData.Speakers.speakerOne, _dialogData.Speakers.speakerTwo);
        _dialogPresenter.Show();

        OnDialogOpened?.Invoke();

        StartCoroutine(DialogCoroutine());
    }

    private IEnumerator DialogCoroutine()
    {
        var phrases = _dialogData.Phrases;

        for(var i = 0; i < phrases.Count; i++)
        {
            _dialogPresenter.DisplayMessage(phrases[i]);

            yield return new WaitForSeconds(_timeUntilCanSkeep);

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        _dialogPresenter.Hide();
        OnDialogClosed?.Invoke();
    }
}
