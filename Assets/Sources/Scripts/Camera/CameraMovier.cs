using DG.Tweening;
using UnityEngine;
using Zenject;

public class CameraMovier : MonoBehaviour
{
    [SerializeField] private Transform _gamePosition;

    [Inject] private RunStarter _runStarter;

    private float _speed = 1.5f;

    private void OnEnable()
    {
        _runStarter.RunStarted += OnRunStarted;
    }

    private void OnDisable()
    {
        _runStarter.RunStarted += OnRunStarted;
    }

    private void OnRunStarted()
    {
        transform.DOLocalMove(_gamePosition.position, _speed);
    }
}
