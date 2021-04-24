using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUserMovementInputManager
{
    Action<Vector2> OnMovementInput { get; set; }
    Action OnJumpInput { get; set; }
    Action OnSprintToggle { get; set; }
}
