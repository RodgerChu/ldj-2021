using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundation.Interactions
{
    public interface ICollidedWithInteractableEventProvider
    {
        ObserverList<ICollidedWithInteractableEventHolder> OnCollidedWithInteractableObservers { get; }
    }
}
