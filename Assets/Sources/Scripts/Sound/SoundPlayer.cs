using UnityEngine;
using Zenject;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip _sound;
    [SerializeField] private float _volume;

    [Inject] private AudioSource _playerSource;

    public SoundPlayer(AudioClip sound, float volume, AudioSource playerSource)
    {
        _sound = sound;
        _volume = volume;
        _playerSource = playerSource;
    }

    public void PlaySound()
    {
        _playerSource.PlayOneShot(_sound, _volume);
    }
}

public static class SoundPlayerIds
{
    public const string BrickPile = "pile";
}