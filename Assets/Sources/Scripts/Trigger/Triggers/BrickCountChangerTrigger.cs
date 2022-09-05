using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]

public class BrickCountChangerTrigger : MonoBehaviour
{
    [SerializeField] private int _deltaBricks;

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
