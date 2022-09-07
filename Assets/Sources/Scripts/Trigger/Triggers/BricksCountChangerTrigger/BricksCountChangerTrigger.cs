using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BricksCountChangerTrigger : MonoBehaviour
{
    [SerializeField] protected int _deltaBricks;

    public event UnityAction<int> ChangeBrickCount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out CharacterMovier characterMovier))
        {
            ChangeBrickCount?.Invoke(_deltaBricks);
            gameObject.SetActive(false);
        }
    }
}
