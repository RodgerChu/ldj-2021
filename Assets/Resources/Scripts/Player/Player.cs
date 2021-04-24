using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Character _character;
    [SerializeField] private PlayerLightController _lightController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        var gObject = collision.gameObject;
        var glowworm = gObject.GetComponent<GlowwormCollectable>();
        if (glowworm != null)
        {
            if (_lightController.AddPower())
                Destroy(glowworm.gameObject);
        }
    }
}
