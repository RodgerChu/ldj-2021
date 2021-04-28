using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundation.Movement
{
    public class PlayerMovementProviderKeyboard: AbstractService<IPlayerMovementInputProvider>, IPlayerMovementInputProvider
    {
        public IObserverList<IPlayerMovementInputHandler> InputObservers => _observers;
        private ObserverList<IPlayerMovementInputHandler> _observers;

        private void Update()
        {
            var userInput = Vector2.zero;
            userInput.x = Input.GetAxis("Horizontal");

            if (Input.GetKeyDown(KeyCode.Space))
                userInput.y = 1;

            if (userInput != Vector2.zero)
                SendUserInput(userInput);
        }

        private void SendUserInput(Vector2 input)
        {
            foreach (var observer in _observers.Enumerate())
                observer.OnMovementInput(input);
        }
    }
}
