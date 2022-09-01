using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HightObstacleTrigger : Trigger
{
    public event UnityAction HighObstacleEnter;

    protected override void OnEnter(ITriggered triggered)
    {
        HighObstacleEnter?.Invoke();
    }
}
