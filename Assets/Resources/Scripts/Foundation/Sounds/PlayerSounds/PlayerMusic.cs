using Foundation.Character.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundation.Sound
{
    public class PlayerMusic : AbstractService<IMusicPlayer>, IMusicPlayer
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
