using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class EventStarter : MonoBehaviour
{
    [SerializeField] protected HintPresenter _hint;
    [SerializeField] protected string _hintAlias;

    protected bool _interacted = false;
    private bool _active = false;

    protected abstract void OnInteract();

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _active)
        {
            OnInteract();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsPlayer(collision.gameObject))
        {
            _active = true;
            _hint.Show(_hintAlias);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (IsPlayer(collision.gameObject))
        {
            _active = false;
            _hint.Hide();
        }
    }

    private bool IsPlayer(GameObject gObject)
    {
        return gObject.GetComponent<Player>();
    }
}
