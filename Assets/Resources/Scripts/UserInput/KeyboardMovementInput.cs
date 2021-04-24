using System;
using UnityEngine;

public class KeyboardMovementInput : MonoBehaviour, IUserMovementInputManager
{
    public Action<Vector2> OnMovementInput { get; set; }
    public Action OnJumpInput { get; set; }
    public Action OnSprintToggle { get; set; }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
            OnMovementInput?.Invoke(new Vector2(-1, 0));
        else if (Input.GetKey(KeyCode.D))
            OnMovementInput?.Invoke(new Vector2(1, 0));

        if (Input.GetKeyDown(KeyCode.Space))
            OnJumpInput?.Invoke();

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            OnSprintToggle?.Invoke();
    }
}
