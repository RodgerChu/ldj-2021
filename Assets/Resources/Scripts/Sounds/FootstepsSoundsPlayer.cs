using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FootstepsSoundsPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] _clips;
    [SerializeField] private float _delay = 0.3f;

    [Inject] private SoundController _soundController;

    private int _currentClip = 0;
    private Coroutine _playingCoroutine;

    public void Play()
    {
        if (_playingCoroutine != null)
            return;

        _playingCoroutine = StartCoroutine(SoundCoroutine());
    }

    public void Stop()
    {
        if (_playingCoroutine == null)
            return;

        StopCoroutine(_playingCoroutine);
        _playingCoroutine = null;
    }

    private IEnumerator SoundCoroutine()
    {
        while(true)
        {
            _soundController.PlaySound(_clips[_currentClip]);

            _currentClip++;
            if (_currentClip >= _clips.Length)
                _currentClip = 0;

            yield return new WaitForSeconds(_delay);
        }
    }
}
