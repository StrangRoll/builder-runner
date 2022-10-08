using DG.Tweening;
using UnityEngine;
using Zenject;

public class CameraMovier : MonoBehaviour
{
    [SerializeField] private Transform _gamePosition;

    [Inject] private WorldInputRoot _worldInput;

    private float _speed = 1.5f;

    private void OnEnable()
    {
        _worldInput.RunStarted += OnRunStarted;
    }

    private void OnDisable()
    {
        _worldInput.RunStarted += OnRunStarted;
    }

    private void OnRunStarted()
    {
        transform.DOLocalMove(_gamePosition.position, _speed);
    }
}
