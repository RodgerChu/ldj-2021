using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DialogStarter : EventStarter
{
    [SerializeField] private DialogData _dialogData;
    [SerializeField] private CharacterInputController _charController;

    [Inject]
    private DialogPopupController _dialogController;

    protected override void OnInteract()
    {
        if (!_interacted)        
            _dialogController.StartDialog(_dialogData);

        _hint.Hide();
        _interacted = true;
    }
}
