using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Foundation.Movement;
using Foundation.Interactions;

namespace Foundation.Character.StateMachine
{
    public interface IStateMachine: IPlayerMovementInputHandler, IInteractionInputHolder, IPlayerLandedEventHolder
    {
        IState CurrentState { get; }
    }
}
