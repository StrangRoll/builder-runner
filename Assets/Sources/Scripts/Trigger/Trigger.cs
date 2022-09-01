using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public abstract class Trigger : MonoBehaviour 
{
    private Collider _collider;
    private bool _isEnable = true;

    public event UnityAction Enter;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ITriggered triggered) && _isEnable)
        {
            _isEnable = false;
            Enter?.Invoke();
            OnEnter(triggered);
        }
    }

    protected virtual void OnEnter(ITriggered triggered) { }

}
