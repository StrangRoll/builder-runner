using UnityEngine;
using Zenject;

public class WorldInputRootInstaller : MonoInstaller
{
    [SerializeField] private WorldInputRoot _worldInputRoot;

    public override void InstallBindings()
    {
        Container
            .Bind<WorldInputRoot>()
            .FromInstance(_worldInputRoot);
    }
}