using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventStarter : MonoBehaviour
{
    [SerializeField] private HintPresenter _hint;
    [SerializeField] private string _hintAlias;

    public UnityEvent<GameObject> OnInteract;

    private bool _active = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _active)
        {
            OnInteract.Invoke(gameObject);
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
        Debug.Log("exit");
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
