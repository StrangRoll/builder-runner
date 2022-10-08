using DG.Tweening;
using UnityEngine;
using Zenject;

public class CameraMovier : MonoBehaviour
{
    [SerializeField] private Transform _gamePosition;

    [Inject] private WorldInputRoot _worldInput;

    private float _speed = 1.5f;
    private Vector3 _startPosition;

    private void OnEnable()
    {
        _worldInput.RunStarted += OnRunStarted;
        _worldInput.LevelEnded += OnLevelEnded;
        _startPosition = transform.position;
    }

    private void OnDisable()
    {
        _worldInput.RunStarted -= OnRunStarted;
        _worldInput.LevelEnded -= OnLevelEnded;
    }

    private void OnRunStarted()
    {
        transform.DOLocalMove(_gamePosition.position, _speed);
    }

    private void OnLevelEnded()
    {
        transform.position = _startPosition;
    }
}
