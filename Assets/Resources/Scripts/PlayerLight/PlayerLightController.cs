using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerLightController : MonoBehaviour
{
    [SerializeField] private LightSettings _lightSettings;

    [Space]
    [SerializeField] private Light2D _playerLight;

    public Action OnLightFaded;

    private float _maximumLightRadius => _lightSettings.MaximumLightRadius;
    private float _minimalLightRadius => _lightSettings.MinimalLightRadius;
    private float _lightFadeDelayAfterLightPowerUp => _lightSettings.LightFadeDelayAfterLightPowerUp;
    private float _lightFadeTickValue => _lightSettings.LightFadeTickValue;
    private float _lightFadeTickTime => _lightSettings.LightFadeTickTime;

    private Coroutine _fadeCoroutine;
    private float _delay = 0f;

    private void Start()
    {
        _playerLight.pointLightOuterRadius = _lightSettings.MaximumLightRadius;
        StartFadeLight();
    }

    public bool AddPower()
    {
        var currPower = _playerLight.pointLightOuterRadius;
        var additionalPower = _maximumLightRadius / 10;
        currPower += additionalPower;

        if (currPower > _maximumLightRadius)
        {
            return false;
        }

        _playerLight.pointLightOuterRadius = currPower;
        _delay = _lightFadeDelayAfterLightPowerUp;

        return true;
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

    public void ResetLight()
    {
        _playerLight.pointLightOuterRadius = _lightSettings.MaximumLightRadius;
    }

    private IEnumerator FadeCoroutine()
    {
        var callbackFired = false;
        while(true)
        {
            if (_delay != 0)
            {
                yield return new WaitForSeconds(_delay);
                _delay = 0f;
            }

            while (_playerLight.pointLightOuterRadius < _minimalLightRadius)
            {
                if (!callbackFired)
                    OnLightFaded?.Invoke();
                callbackFired = true;

                yield return null;
            }

            _playerLight.pointLightOuterRadius -= _lightFadeTickValue;
            yield return new WaitForSeconds(_lightFadeTickTime);
        }

    }
}
