using System;
using UnityEngine;

[RequireComponent(typeof(PlayerInputRouter))]


public class PlayerPresenter : MonoBehaviour
{
    public event Action<float> MoveSide;
    public event Action Start;

    private Player _player;
    private PlayerInputRouter _inputRouter;

    private void Awake()
    {
        _player = new Player(transform.position);
        MoveSide += _player.OnMoveSide;
        Start += _player.OnStart;
        _inputRouter = GetComponent<PlayerInputRouter>();
    }

    private void OnEnable()
    {
        _inputRouter.MovedSide += OnMovedSide;
        _inputRouter.Started += OnStarted;
        _player.Moved += OnMove;
    }

    private void Update()
    {
        _player.Update(Time.deltaTime);
    }

    private void OnDisable()
    {
        _inputRouter.MovedSide -= OnMovedSide;
        _inputRouter.Started -= OnStarted;
        _player.Moved -= OnMove;
    }

    private void OnMovedSide(float delta)
    {
        MoveSide?.Invoke(delta);
    }

    private void OnStarted()
    {
        Start?.Invoke();
    }

    private void OnMove(Vector3 newPosition)
    {
        transform.position = newPosition;
    }

    private void RemoveModel()
    {
        MoveSide -= _player.OnMoveSide;
        Start -= _player.OnStart;
        _player = null;
    }
}
