using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BrickCountChangerZoneTriggerInstaller : MonoInstaller
{
    [SerializeField] private BrickCountChangerZoneTrigger[] _triggers;

    public override void InstallBindings()
    {
        Container
            .Bind<IEnumerable<BrickCountChangerZoneTrigger>>()
            .FromInstance(_triggers);
    }
}