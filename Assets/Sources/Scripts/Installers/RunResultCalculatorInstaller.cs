using UnityEngine;
using Zenject;

public class RunResultCalculatorInstaller : MonoInstaller
{
    [SerializeField] private RunResultCalculator _runResultCalculator;

    public override void InstallBindings()
    {
        Container
            .Bind<RunResultCalculator>()
            .FromInstance(_runResultCalculator);
    }
}