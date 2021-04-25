using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Light Settings", menuName = "Settings/Light Settings", order = 1)]
public class LightSettings : ScriptableObject
{
    public float LightFadeTickTime = 0.1f;
    public float LightFadeTickValue = 0.02f;
    public float LightFadeDelayAfterLightPowerUp = 5f;

    [Space]
    public float StartingLightRadius = 3f;
    public float MinimalLightRadius = 0.5f;
    public float MaximumLightRadius = 6f;

    [Space]
    public bool WillFadeAway = true;
    public bool CanCollectFireflyiesOverLimmit = true;
}
