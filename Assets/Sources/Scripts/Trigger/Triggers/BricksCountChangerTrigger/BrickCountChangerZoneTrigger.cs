using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class BrickCountChangerZoneTrigger : BricksCountChangerTrigger
{
    public event UnityAction<int> SetDeltaBrick;
    
    private void Awake()
    {
        SetDeltaBrick?.Invoke(_deltaBricks);    
    }
}
