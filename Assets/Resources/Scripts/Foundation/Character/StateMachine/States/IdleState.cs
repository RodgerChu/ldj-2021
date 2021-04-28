using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundation.Character.StateMachine
{
    public class IdleState : IState, IStateChangedEventProvider
    {
        public bool CanInterract => true;
        public bool IsMoving => false;
        public bool IsInAir => false;

        public ObserverList<IStateChangedEventHolder> OnStateChangedObservers => _observers;
        private ObserverList<IStateChangedEventHolder> _observers = new ObserverList<IStateChangedEventHolder>();

        public void OnMovementInput(Vector2 input)
        {
            if (input.y != 0)
                TransitionToState(new JumpState());
            else if (input.x != 0)
                TransitionToState(new RunState());
        }

        private void TransitionToState(IState newState)
        {
            foreach (var obs in _observers.Enumerate())
                obs.OnStateChanged(newState);
        }
    }
}
