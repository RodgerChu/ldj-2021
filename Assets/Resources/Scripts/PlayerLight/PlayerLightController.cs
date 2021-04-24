using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerLightController : MonoBehaviour
{
    [SerializeField] private float _lightFadeTickTime = 0.5f;
    [SerializeField] private float _lightFadeTickValue = 0.1f;
    [SerializeField] private float _lightFadeDelayAfterLightPowerUp = 5f;

    [Space]
    [SerializeField] private float _minimalLightRadius = 0.5f;
    [SerializeField] private float _maximumLightRadius = 3.5f;

    [Space]
    [SerializeField] private Light2D _playerLight;

    private Coroutine _fadeCoroutine;
    private float _delay = 0f;

    private void Start()
    {
        StartFadeLight();
    }

    public void AddPower(float power)
    {
        var currPower = _playerLight.pointLightOuterRadius;
        currPower += power;

        if (currPower > _maximumLightRadius)
            currPower = _maximumLightRadius;

        _playerLight.pointLightOuterRadius = currPower;
        _delay = _lightFadeDelayAfterLightPowerUp;
    }

    public void StartFadeLight()
    {
        if (_fadeCoroutine != null)
        {
            Debug.LogError("Trying to start fade light coroutine twice");
            return;
        }

        _fadeCoroutine = StartCoroutine(FadeCoroutine());
    }

    public void StopFadeLight()
    {
        StopCoroutine(_fadeCoroutine);
        _fadeCoroutine = null;
    }

    private IEnumerator FadeCoroutine()
    {
        while(true)
        {
            if (_delay != 0)
            {
                yield return new WaitForSeconds(_delay);
                _delay = 0f;
            }

            while (_playerLight.pointLightOuterRadius < _minimalLightRadius)
                yield return null;

            _playerLight.pointLightOuterRadius -= _lightFadeTickValue;
            yield return new WaitForSeconds(_lightFadeTickTime);
        }

    }
}
