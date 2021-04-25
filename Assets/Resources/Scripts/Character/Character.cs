using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class Character : MonoBehaviour
{
    [SerializeField] 
    private Rigidbody2D _rb;
    public Rigidbody2D Rb => _rb;

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
    
    [SerializeField] private int[] _layers;
    [SerializeField] private GameObject _landParticles;
    [SerializeField] private Transform _spawnPoint;

    public void MoveLeft(bool isLeftMoving)
    {
        _horizontalDirection = -1f;
        _commonFlipper.SetFlip(_horizontalDirection);
    }
    public void MoveRight(bool isRightMoving)
    {
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
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (_layers.Contains(other.gameObject.layer))
        {
            SpawnGroundParticles(isLanding:true);
        }
        else
        {
            SpawnGroundParticles(isLanding:false);
        }
    }

    public void SpawnGroundParticles(bool isLanding)
    {
        if (isLanding)
        {
            Instantiate(_landParticles, new Vector3(_spawnPoint.transform.position.x,_spawnPoint.transform.position.y,
                _spawnPoint.transform.position.z - 2f), _spawnPoint.rotation);
        }
        else return;
    }
}
