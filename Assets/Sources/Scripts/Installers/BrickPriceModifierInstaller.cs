using UnityEngine;
using Zenject;

public class BrickPriceModifierInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<BrickPriceModifier>()
            .AsSingle();
    }
}