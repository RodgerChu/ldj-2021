using Zenject;
using UnityEngine;

public class ConfigurationsInstaller : MonoInstaller
{
    [SerializeField] private AudioSource _musicSouce;
    [SerializeField] private AudioSource _soundsSouce;

    public override void InstallBindings()
    {
        Container.Bind<SoundController>().AsSingle().WithArguments(_musicSouce, _soundsSouce).NonLazy();
    }
}
