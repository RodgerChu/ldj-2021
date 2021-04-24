using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] 
    private Character _target;
    private void Update()
    {
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
