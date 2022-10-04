using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInputRoot))]
public class CharacterMovier : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _turnSpeed;
    [SerializeField] private Transform _road;
    [SerializeField] private float _roadWidth;

    [Inject] private RunStarter _runStarter;
    [Inject] private Finish _finish;

    private Rigidbody _rigidbody;
    private bool _isMoving = false;
    private Vector3 _moveSide = Vector3.zero;
    private PlayerInputRoot playerInputRoot;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        playerInputRoot = GetComponent<PlayerInputRoot>();
        _roadWidth = _roadWidth / 2;
    }

    private void OnEnable()
    {
        playerInputRoot.Move += OnMove;
        _runStarter.RunStarted += OnRunStarted;
        _finish.PlayerFinish += OnPlayerFinish;
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
        _runStarter.RunStarted -= OnRunStarted;
        _finish.PlayerFinish -= OnPlayerFinish;
    }

    public void OnMove(Vector3 delta)
    {
        if (((transform.position + delta).x > _road.position.x - _roadWidth) && ((transform.position + delta).x < _road.position.x + _roadWidth))
            _moveSide += delta * _turnSpeed;
    }

    private void OnRunStarted()
    {
        _isMoving = true;
    }

    private void OnPlayerFinish()
    {
        _isMoving = false;
        _rigidbody.velocity = Vector3.zero;
    }
}