using System.Collections.Generic;
using Zenject;

public class BrickCountChangerTriggerInstaller : MonoInstaller
{
    private BricksCountChangerTrigger[] _triggers;

    public override void InstallBindings()
    {
        _triggers = FindObjectsOfType<BricksCountChangerTrigger>();

        Container
            .Bind<IEnumerable<BricksCountChangerTrigger>>()
            .FromInstance(_triggers);
    }
}