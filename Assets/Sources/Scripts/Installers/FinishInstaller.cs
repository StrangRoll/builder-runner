using UnityEngine;
using Zenject;

public class FinishInstaller : MonoInstaller
{
    [SerializeField] private Finish _finish;

    public override void InstallBindings()
    {
        Container
            .Bind<Finish>()
            .FromInstance(_finish);
    }
}