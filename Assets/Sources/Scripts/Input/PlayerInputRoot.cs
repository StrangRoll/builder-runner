using System;
using UnityEngine;

public class PlayerInputRoot : MonoBehaviour
{
    private bool _isPressed = false;

    public event Action<Vector3> Move;
    public event Action Started;

    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.SideMove.performed += ctx => OnSideMove();
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
            var moveDirection = new Vector3(delta, 0, 0);
            Move?.Invoke(moveDirection);
        }
    }

    private void OnPress()
    {
        _isPressed = !_isPressed;
    }
}
