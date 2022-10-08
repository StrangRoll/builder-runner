using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class WorldInputRoot : MonoBehaviour
{
    [Inject] private RunStartButton _runControlButton;
    [Inject] private Finish _finish;

    private bool _isStarted = false;
    private bool _isResultDone = false;

    public event UnityAction RunStarted;
    public event UnityAction LevelEnded;

    private void OnEnable()
    {
        _runControlButton.RunControlButtonPressed += OnRunControlButtonPressed;
        _finish.PlayerFinish += OnPlayerFinish;
    }

    private void OnDisable()
    {
        _runControlButton.RunControlButtonPressed -= OnRunControlButtonPressed;
        _finish.PlayerFinish -= OnPlayerFinish;
    }

    private void OnPlayerFinish()
    {
        _isResultDone = true;
    }

    private void OnRunControlButtonPressed()
    {
        if (_isStarted == false)
        {
            _isStarted = true;
            RunStarted?.Invoke();
        }

        if (_isResultDone)
        {
            _isStarted = false;
            _isResultDone = false;
            LevelEnded?.Invoke();
        }
    }
}
