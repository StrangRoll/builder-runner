using System;
using UnityEngine;

public class Player
{
    private Vector3 _position;
    private bool _isStarted = false;
    private float _forwardSpeed = 3;
    private float _sideSpeed = 0.003f;

    private Action _startAction;
    private Action<float> _moveSideAction;

    public event Action<Vector3> Moved;

    public Player(Vector3 position)
    {
        _position = position;
    }

    public void OnMoveSide(float delta)
    {
        var deltaMove = new Vector3(_sideSpeed * delta, 0, 0);
        var position = _position + deltaMove;
        _position = position;
    }

    public void MoveForward(float deltaTime)
    {
        var deltaMove = new Vector3(0, 0, _forwardSpeed * deltaTime);
        var position = _position + deltaMove;
        _position = position;
    }

    public void OnStart()
    {
        _isStarted = true;
    }

    public void Update(float deltaTime)
    {
        if (_isStarted)
        {
            MoveForward(deltaTime);
            Moved?.Invoke(_position);
        }
    }
}
