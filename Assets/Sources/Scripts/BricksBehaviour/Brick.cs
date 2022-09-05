using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Brick : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public event UnityAction BrickFell;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            Fall();
            BrickFell?.Invoke();
        }
    }

    public void Fall()
    {
        _rigidbody.constraints = RigidbodyConstraints.None;
    }
}
