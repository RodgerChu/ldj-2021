using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class DialogStarter : EventStarter
{
    [SerializeField] private DialogData _dialogData;

    [SerializeField] private UnityEvent _onDialogEnded;

    [Inject]
    private DialogPopupController _dialogController;

    private void Start()
    {
        _dialogController.OnDialogClosed += () => _onDialogEnded?.Invoke();
    }

    protected override void OnInteract()
    {
        base.OnInteract();       
        _dialogController.StartDialog(_dialogData);
        _hint.Hide();
    }
}
