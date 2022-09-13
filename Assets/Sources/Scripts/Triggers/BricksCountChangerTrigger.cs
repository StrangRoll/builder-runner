using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public abstract class BricksCountChangerTrigger : MonoBehaviour
{
    [SerializeField] protected int _deltaBricks;

    public event UnityAction<int> ChangeBrickCount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out CharacterMovier characterMovier))
        {
            OnEnter();
        }
    }

    protected virtual void ReadyToChangeBrickCount()
    {
        ChangeBrickCount?.Invoke(_deltaBricks);
    }

    protected abstract void OnEnter();
}