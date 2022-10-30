using UnityEngine;
using Zenject;

public class PlayerAudioSourceInstaller : MonoInstaller
{
    [SerializeField] private AudioSource _playerSource;

    public override void InstallBindings()
    {
        Container.Bind<AudioSource>()
            .FromInstance(_playerSource);
    }
}