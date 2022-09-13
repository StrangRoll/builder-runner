using UnityEngine.Events;
using UnityEngine;
using DG.Tweening;
using Zenject;

[RequireComponent(typeof(BricksPileTrigger))]
public class BricksPileView : MonoBehaviour
{
    [Inject] BrickCellFinder _brickCellFinder;
    [Inject] Transform _playersBrickParent;

    private float _jumpDuration = 1.5f;
    private float _jumpPower = 3f;
    private BricksPileTrigger _trigger;
    private int _jumpsCount = 1;

    public event UnityAction JumpOver; 

    private void OnEnable()
    {
        _trigger = GetComponent<BricksPileTrigger>();
        _trigger.Enter += OnEnter;
    }

    private void OnDisable()
    {
        _trigger.Enter -= OnEnter;
    }

    private void OnEnter()
    {
        transform.SetParent(_playersBrickParent, true);
        var finalPosition = new Vector3(0, _brickCellFinder.GetHighestBrickHight(), 0);
        transform.DOLocalJump(finalPosition, _jumpPower, _jumpsCount, _jumpDuration).OnComplete(OnJumpOver);
    }

    private void OnJumpOver()
    {
        JumpOver?.Invoke();
        gameObject.SetActive(false);
    }
}
