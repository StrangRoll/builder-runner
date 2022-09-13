using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BrickCountChangerTriggerInstaller : MonoInstaller
{
    [SerializeField] private BricksCountChangerTrigger[] _triggers;

    public override void InstallBindings()
    {
        Container
            .Bind<IEnumerable<BricksCountChangerTrigger>>()
            .FromInstance(_triggers);
    }
}