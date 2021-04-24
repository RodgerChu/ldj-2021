using Zenject;
using UnityEngine;

public class ConfigurationsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<SoundOptions>().AsSingle().NonLazy();
    }
}
