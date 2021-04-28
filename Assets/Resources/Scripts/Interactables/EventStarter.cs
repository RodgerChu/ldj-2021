using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class EventStarter : MonoBehaviour
{
    [Inject] protected HintPresenter _hint;

    [SerializeField] protected string _hintAlias = "hint_press_E";
    [SerializeField] protected UnityEvent _onInteracted;

    protected bool _interacted = false;
    private bool _active = false;

    protected virtual void OnInteract()
    {
        _interacted = true;
        _onInteracted?.Invoke();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _active)
        {
            OnInteract();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsPlayer(collision.gameObject) && !_interacted)
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
        return gObject.GetComponent<Character>();
    }
}
