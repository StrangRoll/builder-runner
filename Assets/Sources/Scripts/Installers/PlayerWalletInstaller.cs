using UnityEngine;
using Zenject;

public class PlayerWalletInstaller : MonoInstaller
{
    [SerializeField] private PlayerWallet _playerWallet;
    public override void InstallBindings()
    {
        Container
            .Bind<PlayerWallet>()
            .FromInstance(_playerWallet);
    }
}