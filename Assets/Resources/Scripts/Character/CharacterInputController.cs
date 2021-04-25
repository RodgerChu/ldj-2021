using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CharacterInputController : MonoBehaviour
{
    [SerializeField] 
    private Character _target;

    [InjectOptional]
    private DialogPopupController _dialogController;

    private bool _recieveInput = true;

    private void Start()
    {
        if (_dialogController != null)
        {
            _dialogController.OnDialogOpened += () => _recieveInput = false;
            _dialogController.OnDialogClosed += () => _recieveInput = true;
        }
    }

    private void Update()
    {
        if (!_recieveInput)
            return;

        if (MoveLeftHold())
        {
            _target.MoveLeft(true);
        }

        if (MoveRightHold())
        {
            _target.MoveRight(true);
        }

        if (JumpPush())
        {
            _target.Jump(true);
        }
    }

    public bool MoveLeftHold()
    {
        return Input.GetKey(KeyCode.LeftArrow);
    }
    
    public bool MoveRightHold()
    {
        return Input.GetKey(KeyCode.RightArrow);
    }

    public bool JumpPush()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
