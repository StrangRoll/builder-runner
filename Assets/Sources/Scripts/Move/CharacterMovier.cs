using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInputRoot))]
public class CharacterMovier : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _turnSpeed;

    private Rigidbody _rigidbody;
    private bool _isMoving = false;
    private Vector3 _moveSide = Vector3.zero;
    private PlayerInputRoot playerInputRoot;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        playerInputRoot = GetComponent<PlayerInputRoot>();
    }

    private void OnEnable()
    {
        playerInputRoot.Move += OnMove;
    }

    private void FixedUpdate()
    {
        if (_isMoving)
        {
            var moveForward = Vector3.forward * _moveSpeed;
            _rigidbody.velocity = _moveSide + moveForward;
            _moveSide = Vector3.zero;
        }
    }

    private void OnDisable()
    {
        playerInputRoot.Move -= OnMove;
    }

    public void OnMove(Vector3 delta)
    {
        if (_isMoving == false)
            _isMoving = true;

        _moveSide += delta * _turnSpeed;
    }
}
