using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HightObstacleTrigger : Trigger
{
    public event UnityAction DestroyBricksConstruction;

    protected override void OnEnter(ITriggered triggered)
    {
        DestroyBricksConstruction?.Invoke();
    }
}
