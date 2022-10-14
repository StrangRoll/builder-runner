using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class WorldInputRoot : MonoBehaviour
{
    [Inject] private Finish _finish;

    private bool _isStarted = false;
    private bool _isResultDone = false;
    private PlayerInput _playerInput;

    public event UnityAction RunStarted;
    public event UnityAction LevelEnded;

    private void Awake()
    {
        _playerInput = new PlayerInput();

    }

    private void OnEnable()
    {
        _finish.PlayerFinish += OnPlayerFinish;
        _playerInput.Player.ChangeRunState.performed += ctx => OnChangeRunState();
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _finish.PlayerFinish -= OnPlayerFinish;
        _playerInput.Player.ChangeRunState.performed -= ctx => OnChangeRunState();
        _playerInput.Enable();
    }

    private void OnPlayerFinish()
    {
        _isResultDone = true;
    }

    private void OnChangeRunState()
    {
        if (_isStarted == false)
        {
            _isStarted = true;
            RunStarted.Invoke();
        }

        if (_isResultDone)
        {
            _isStarted = false;
            _isResultDone = false;
            LevelEnded?.Invoke();
        }
    }
}
