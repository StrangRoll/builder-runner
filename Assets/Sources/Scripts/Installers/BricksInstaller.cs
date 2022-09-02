using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BricksInstaller : MonoInstaller
{
    [SerializeField] private List<Trigger> _triggers;

    public override void InstallBindings()
    {
        Container
            .Bind<IEnumerable<Trigger>>()
            .FromInstance(_triggers);
    }
}