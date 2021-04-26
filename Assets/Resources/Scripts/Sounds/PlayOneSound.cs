using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayOneSound : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;

    [Inject] private SoundController _controller;

    public void Play()
    {
        _controller.PlaySound(_clip);
    }
}
