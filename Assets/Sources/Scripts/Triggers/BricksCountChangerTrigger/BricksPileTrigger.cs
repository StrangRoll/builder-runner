using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BricksPileView))]
public class BricksPileTrigger : BricksCountChangerTrigger
{
    public event UnityAction Enter;

    private BricksPileView _view;

    private void OnEnable()
    {
        _view = GetComponent<BricksPileView>();
        _view.JumpOver += OnJumpOver;
    }

    private void OnDisable()
    {
        _view.JumpOver -= OnJumpOver;
    }

    protected override void OnEnter()
    {   
        Enter?.Invoke();
    }

    private void OnJumpOver()
    {
        ReadyToChangeBrickCount();
    }
}
