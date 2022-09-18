using UnityEngine;
using Zenject;

public class RunStarterInstaller : MonoInstaller
{
    [SerializeField] private RunStarter _runStarter;

    public override void InstallBindings()
    {
        Container
            .Bind<RunStarter>()
            .FromInstance(_runStarter);
    }
}