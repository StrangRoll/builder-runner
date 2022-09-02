using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Brick brick) == false)
            OnHighObstacleEnter();
    }

    private void OnHighObstacleEnter()
    {
        var rigidbody = gameObject.AddComponent<Rigidbody>();
    }
}
