using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof (SoundPlayer))]
public class BricksCountChangerView : MonoBehaviour
{
    [SerializeField] private float _animationTime;

    [Inject] public readonly IEnumerable<BrickCell> _brickCells;

    private bool _isRunning = false;
    private WaitForSeconds _whaitEndOfAnimationTime;
    private Queue<IEnumerator> _actionQueue;
    private SoundPlayer _countChangerSound;

    private void Awake()
    {
        _countChangerSound = GetComponent<SoundPlayer>();
        _whaitEndOfAnimationTime = new WaitForSeconds(_animationTime);
        _actionQueue = new Queue<IEnumerator>();

        foreach (var brickCell in _brickCells)
        {
            brickCell.BrickAdded += OnBrickAdded;
            brickCell.BrickRemoved += OnBrickRemoved;
        }
    }

    private void OnDestroy()
    {
        foreach (var brickCell in _brickCells)
        {
            brickCell.BrickAdded -= OnBrickAdded;
            brickCell.BrickRemoved -= OnBrickRemoved;
        }
    }

    private void OnBrickAdded(Brick brick)
    {
        brick.GetComponent<MeshRenderer>().enabled = false;

        if (_isRunning == false)
        {
            _isRunning = true;
            StartCoroutine(AddingAnimation(brick));
        }
        else
        {
            var newAction = AddingAnimation(brick);
            _actionQueue.Enqueue(newAction);
        }
    }

    private void OnBrickRemoved(Brick brick)
    {
        if (_isRunning == false)
        {
            _isRunning = true; 
            StartCoroutine(RemovingAnimation(brick));
        }
        else
        {
            var newAction = RemovingAnimation(brick);
            _actionQueue.Enqueue(newAction);
        }
    }

    private IEnumerator AddingAnimation(Brick brick)
    {
        _countChangerSound.PlaySound();
        brick.GetComponent<MeshRenderer>().enabled = true;
        yield return _whaitEndOfAnimationTime;
        TryDoNextAnimation();
    }

    private IEnumerator RemovingAnimation(Brick brick)
    {
        _countChangerSound.PlaySound();
        brick.gameObject.SetActive(false);
        yield return _whaitEndOfAnimationTime;
        TryDoNextAnimation();
    }

    private void TryDoNextAnimation()
    {
        if (_actionQueue.Count > 0)
        {
            var newAction = _actionQueue.Dequeue();
            StartCoroutine(newAction);
        }
        else
        {
            _isRunning = false;
        }
    }
}
