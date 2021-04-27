using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerableZone : MonoBehaviour
{
    [SerializeField] private UnityEvent _onTriggered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _onTriggered?.Invoke();
    }
}
