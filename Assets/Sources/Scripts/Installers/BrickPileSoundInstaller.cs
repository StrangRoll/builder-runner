using UnityEngine;
using Zenject;

public class BrickPileSoundInstaller : MonoInstaller
{
    [SerializeField] private AudioClip _sound;
    [SerializeField] private float _volume;

    [Inject] private AudioSource _playerSource;

    private SoundPlayer _brickPileSound;

    public override void InstallBindings()
    {
        _brickPileSound = new SoundPlayer(_sound, _volume, _playerSource);

        Container.Bind<SoundPlayer>()
            .WithId(SoundPlayerIds.BrickPile)
            .FromInstance(_brickPileSound);
    }
}

