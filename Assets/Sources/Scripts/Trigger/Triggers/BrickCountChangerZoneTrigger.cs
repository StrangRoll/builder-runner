using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class BrickCountChangerZoneTrigger : MonoBehaviour
{
    [SerializeField] private int _deltaBricks;

    public event UnityAction<int> ChangeBrickCount;
    public event UnityAction<int> SetDeltaBrick;
    
    private void Awake()
    {
        SetDeltaBrick?.Invoke(_deltaBricks);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out CharacterMovier characterMovier))
        {
            ChangeBrickCount?.Invoke(_deltaBricks);
            gameObject.SetActive(false);
        }
    }
}
