using UnityEngine;
using Zenject;

public class EndRunBrickModifierInstaller : MonoInstaller
{

    public override void InstallBindings()
    {
        Container
            .Bind<EndRunBrickModifier>()
            .AsSingle();
    }
}