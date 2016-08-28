using UnityEngine;
using Zenject;

public class GameManagersInstaller : MonoInstaller
{
    public AudioClip deathSound;
    public override void InstallBindings()
    {
        Container.Bind<IInitializable>().To<PauseManager>().AsSingle();
        Container.Bind<PauseManager>().AsSingle().NonLazy();
        Container.Bind<IInitializable>().To<GameManager>().AsSingle();
        Container.Bind<ITickable>().To<GameManager>().AsSingle();
        Container.Bind<GameManager>().AsSingle().NonLazy();
        Container.BindInstance(deathSound);
    }
}