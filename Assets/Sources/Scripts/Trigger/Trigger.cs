using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public abstract class Trigger : MonoBehaviour 
{
    private Collider _collider;

    public event UnityAction<ITriggered> Enter;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ITriggered triggered))
        {
            Enter?.Invoke(triggered);
            OnEnter(triggered);
        }
    }

    protected virtual void OnEnter(ITriggered triggered) { }

}
