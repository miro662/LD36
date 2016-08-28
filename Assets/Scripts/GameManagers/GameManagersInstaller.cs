﻿using UnityEngine;
using Zenject;

public class GameManagersInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IInitializable>().To<PauseManager>().AsSingle();
        Container.Bind<PauseManager>().AsSingle().NonLazy();
        Container.Bind<GameManager>().AsSingle().NonLazy();
    }
}