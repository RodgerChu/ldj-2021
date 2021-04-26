using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpHelper : MonoBehaviour
{
    [SerializeField] 
    private Character _target;

    private int _maxJumpNumbers = 2;
    private int _currentJumpNumbers;
    public bool isStartJumping;
    public bool isFalling;

    public void Start()
    {
        isStartJumping = false;
    }
    
    public bool Grounded()
    {
        return _target.GroundCheckBox.IsTouchingLayers(LayerMask.GetMask("Foreground", "Platform"));
    }

    public bool MayJump()
    {
        if (_currentJumpNumbers > 0)
        {

            return true;
        }
        else return false;
    }

    public void Jump(bool isJumping)
    {
        if (MayJump())
        {
            _currentJumpNumbers--;
            _target.animator.SetTrigger("takeOf");
            isStartJumping = true;
        }
        
    }
    

    private void Update()
    {
        if (Grounded())
        {
            _currentJumpNumbers = _maxJumpNumbers;
        }
        else
        {
            isFalling = true;
        }
    }
}
