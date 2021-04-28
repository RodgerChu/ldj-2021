using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollisionCheck : MonoBehaviour
{
    [SerializeField] private Character _target;

    private void OnCollisionEnter2D(Collision2D collisionPlatform)
    {
        if (collisionPlatform.gameObject.GetComponent<MovingPlatform>())
        {
            _target.transform.parent = collisionPlatform.transform;
        }
    }
    
    private void OnCollisionExit2D(Collision2D collisionPlatform)
    {
        if (collisionPlatform.gameObject.GetComponent<MovingPlatform>())
        {
            _target.transform.parent = null;
        }
    }
    
}
