using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LocalizationsInstaller : MonoInstaller
{
    [SerializeField] private LocalizationData _localizationData;

    public override void InstallBindings()
    {
        Container.Bind<LocalizationConfig>().AsSingle().WithArguments(_localizationData);
    }
}
