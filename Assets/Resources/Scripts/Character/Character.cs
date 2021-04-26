using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] 
    private Rigidbody2D _rb;
    public Rigidbody2D Rb => _rb;

    public Animator animator;

    [SerializeField]
    private Collider2D _groundCheckBox;
    public Collider2D GroundCheckBox => _groundCheckBox;
    
    [SerializeField] 
    private Collider2D _sideCheckBox;
    public Collider2D SideCheckBox => _sideCheckBox;
    
    [SerializeField] 
    private CommonFlipper _commonFlipper;
    [SerializeField] 
    private JumpHelper _jumpHelper;
    private float _horizontalDirection;
    [SerializeField] 
    float _horizontalVelocity = 5f;
    private float _currentHorizontalVelocity;

    [SerializeField] 
    float _jumpVelocity = 5f;
    public void MoveLeft(bool isLeftMoving)
    {
        animator.SetBool("isRunning", true);
        _horizontalDirection = -1f;
        _commonFlipper.SetFlip(_horizontalDirection);
    }
    public void MoveRight(bool isRightMoving)
    {
        animator.SetBool("isRunning", true);
        _horizontalDirection = 1f;
        _commonFlipper.SetFlip(_horizontalDirection);
    }
    public void Jump(bool isStartJumping)
    {
        _jumpHelper.Jump(isStartJumping);
    }

    private void Start()
    {
        _currentHorizontalVelocity = _horizontalVelocity;
    }

    public void FixedUpdate()
    {
        var velocity = _rb.velocity;
        velocity.x = _horizontalDirection * _currentHorizontalVelocity;
        _horizontalDirection = 0f;
        if (_jumpHelper.isStartJumping)
        {
            velocity.y = _jumpVelocity;
            _jumpHelper.isStartJumping = false;
        }
        _rb.velocity = velocity;
        if (_rb.velocity.x == 0)
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isRunning", false);
        }
        if (_jumpHelper.isFalling && _jumpHelper.Grounded())
        {
            _jumpHelper.isFalling = false;
            animator.SetBool("isJumping", false);
        }
    }
}
