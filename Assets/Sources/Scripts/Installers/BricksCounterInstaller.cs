using UnityEngine;
using Zenject;

public class BricksCounterInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<BricksCounter>()
            .AsSingle();
    }
}