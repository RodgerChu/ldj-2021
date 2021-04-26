using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BackgroundMusicPlayer : MonoBehaviour
{
    [Inject]
    private SoundController _soundController;

    [SerializeField] private AudioClip _clip;
    [SerializeField] private bool _loop;


    private void Start()
    {
        _soundController.PlayMusic(_clip, _loop);
    }
}
