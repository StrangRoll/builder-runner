using UnityEngine;
using Zenject;

public class BrickCellFinderInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
       .Bind<BrickCellFinder>()
       .AsSingle();
    }
}