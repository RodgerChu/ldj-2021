using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Foundation.Movement;

namespace Foundation.Character.StateMachine
{
    public class JumpState : IState, IPlayerLandedEventProvider
    {
        public bool CanInterract => false;
        public bool IsMoving => true;
        public bool IsInAir => true;

        public ObserverList<IPlayerLandedEventHolder> LandedEventObservers => _landedObservers;
        private ObserverList<IPlayerLandedEventHolder> _landedObservers = new ObserverList<IPlayerLandedEventHolder>();

        public ObserverList<IStateChangedEventHolder> OnStateChangedObservers => _stateObservers;
        private ObserverList<IStateChangedEventHolder> _stateObservers = new ObserverList<IStateChangedEventHolder>();

        public void OnMovementInput(Vector2 input)
        {

        }
    }
}
