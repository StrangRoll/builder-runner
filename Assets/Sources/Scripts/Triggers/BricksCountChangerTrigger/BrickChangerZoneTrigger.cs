using UnityEngine;
using UnityEngine.Events;

public class BrickChangerZoneTrigger : BricksCountChangerTrigger
{
    public event UnityAction<int> SetDeltaBrick;

    private void Start()
    {
        SetDeltaBrick?.Invoke(_deltaBricks);
    }

    protected override void OnEnter()
    {
        gameObject.SetActive(false);
        ReadyToChangeBrickCount();
    }
}
