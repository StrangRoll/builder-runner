using System;
using UnityEngine;

public class WorldInputRoot : MonoBehaviour
{
    public event Action Press;

    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
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

    private void OnPress()
    {
        Press?.Invoke();
    }
}
