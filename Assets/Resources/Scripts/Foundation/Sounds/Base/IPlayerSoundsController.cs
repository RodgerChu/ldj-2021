using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundation.Sound
{
    public interface ISoundsPlayer
    {
        void PlaySound(AudioClip clip);
        void Stop();
    }
}