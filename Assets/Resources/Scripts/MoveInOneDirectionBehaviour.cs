using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInOneDirectionBehaviour : MonoBehaviour
{
    [SerializeField] private Vector2 _movementVelocity;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private FootstepsSoundsPlayer _soundPlayer;

    private void Start()
    {
        _soundPlayer.Play();
    }

    void Update()
    {
        _rigidbody.velocity = _movementVelocity;
    }
}
