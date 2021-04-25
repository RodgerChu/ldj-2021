using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DialogControllerInstaller : MonoInstaller
{
    [SerializeField] private DialogPopupController _controller;

    public override void InstallBindings()
    {
        Container.Bind<DialogPopupController>().FromInstance(_controller).AsSingle();
    }
}
