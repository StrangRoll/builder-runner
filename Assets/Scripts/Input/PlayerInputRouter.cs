using System;
using UnityEngine;

public class PlayerInputRouter : MonoBehaviour
{
    private bool _isPressed = false;

    public event Action<float> MovedSide;
    public event Action Started;

    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.SideMove.performed += ctx => OnSideMove();
        _playerInput.Player.Start.performed += ctx => OnStart();
        _playerInput.Player.Press.performed += ctx => OnPress();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void OnSideMove()
    {
        if (_isPressed)
        {
            float delta = _playerInput.Player.SideMove.ReadValue<float>();
            MovedSide?.Invoke(delta);
        }
    }

    private void OnPress()
    {
        _isPressed = !_isPressed;
    }

    private void OnStart()
    {
        Started?.Invoke();
    }
}
