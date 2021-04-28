using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Foundation.Character.StateMachine;

namespace Foundation.Sound
{
    public class PlayerSounds : AbstractService<ISoundsPlayer>, ISoundsPlayer
    {
        [SerializeField] private AudioSource _source;

        public void PlaySound(AudioClip clip)
        {
            _source.clip = clip;
            _source.Play();
        }

        public void Stop()
        {
            _source.Stop();
        }
    }
}
