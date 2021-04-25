using UnityEngine;
using Zenject;

public class HintPresenterInstaller : MonoInstaller
{
    [SerializeField] private HintPresenter _presenter;

    public override void InstallBindings()
    {
        Container.Bind<HintPresenter>().FromInstance(_presenter).AsSingle();
    }
}