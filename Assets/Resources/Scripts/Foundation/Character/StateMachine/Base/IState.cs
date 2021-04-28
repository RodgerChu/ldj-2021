using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Foundation.Movement;
using Foundation.Interactions;

namespace Foundation.Character.StateMachine
{
    public interface IState: IPlayerMovementInputHandler, IStateChangedEventProvider
    {
        bool CanInterract { get; }
        bool IsMoving { get; }
        bool IsInAir { get; }
    }
}
