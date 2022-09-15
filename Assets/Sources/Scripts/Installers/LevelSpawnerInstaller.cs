using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelSpawnerInstaller : MonoInstaller
{
    [SerializeField] private LevelSpawner _levelSpawner;

    public override void InstallBindings()
    {
        Container
            .Bind<LevelSpawner>()
            .FromInstance(_levelSpawner);
    }
}