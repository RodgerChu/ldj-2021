using Foundation.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Foundation.Movement
{
    public class PlayerMovementProviderKeyboard: AbstractService<IPlayerMovementInputProvider>, 
        IPlayerMovementInputProvider, IPauseEventHolder
    {
        public IObserverList<IPlayerMovementInputHandler> InputObservers => _observers;
        private ObserverList<IPlayerMovementInputHandler> _observers = new ObserverList<IPlayerMovementInputHandler>();
        private bool _pauseShown = false;

        [InjectOptional] private IPauseEventProvider _pauseEventProvider;

        public override void Start()
        {
            base.Start();

            if (_pauseEventProvider != null)
                Observe(_pauseEventProvider.OnPauseObservers);
        }

        private void Update()
        {
            if (_pauseShown)
                return;

            var userInput = Vector2.zero;
            userInput.x = Input.GetAxis("Horizontal");

            if (Input.GetKeyDown(KeyCode.Space))
                userInput.y = 1;

            SendUserInput(userInput);
        }

        private void SendUserInput(Vector2 input)
        { 
            foreach (var observer in _observers.Enumerate())
                observer.OnMovementInput(input);
        }

        public void OnPause(bool shown)
        {
            _pauseShown = shown;
        }
    }
}
