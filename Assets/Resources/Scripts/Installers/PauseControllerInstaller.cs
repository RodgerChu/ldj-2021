using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PauseControllerInstaller : MonoInstaller
{
    [SerializeField] private PauseController _controller;

    public override void InstallBindings()
    {
        Container.Bind<PauseController>().FromInstance(_controller).AsSingle();
    }
}
