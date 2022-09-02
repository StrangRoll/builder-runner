using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Brick : MonoBehaviour, ITriggered
{
    private IEnumerable<Trigger> _triggers;

    [Inject]
    private void Construct(IEnumerable<Trigger> triggers)
    {
        foreach (Trigger trigger in triggers)
            trigger.Enter += OnEnter;

        _triggers = triggers;
    }

    private void OnDestroy()
    {
        UnsubscribeAll();
    }

    public void OnEnter(ITriggered triggered)
    {
        if (triggered == this)
        {
            var rigidbody = gameObject.AddComponent<Rigidbody>();
            UnsubscribeAll();
        }
    }

    private void UnsubscribeAll()
    {
        foreach (Trigger trigger in _triggers)
            trigger.Enter -= OnEnter;
    }
}
