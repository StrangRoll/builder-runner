using UnityEngine;
using Zenject;

public class PlayersBrickParentInstaller : MonoInstaller
{
    [SerializeField] Transform _playersBrickParent;

    public override void InstallBindings()
    {
        Container
        .Bind<Transform>()
        .FromInstance(_playersBrickParent);
    }
}