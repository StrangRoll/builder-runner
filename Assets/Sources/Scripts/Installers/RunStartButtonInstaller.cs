using UnityEngine;
using Zenject;

public class RunStartButtonInstaller : MonoInstaller
{
    [SerializeField] private RunStartButton _runStartButton;

    public override void InstallBindings()
    {
        Container
            .Bind<RunStartButton>()
            .FromInstance(_runStartButton);
    }
}