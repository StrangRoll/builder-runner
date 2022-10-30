using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public abstract class BricksCountChangerTrigger : MonoBehaviour
{
    [SerializeField] protected int _deltaBricks;

    public event UnityAction<int> ChangeBrickCount;

    private BrickCountChangeTriggerResetter TriggerResetter;

    private void Awake()
    {
        TriggerResetter = new BrickCountChangeTriggerResetter(transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out CharacterMovier characterMovier))
        {
            OnEnter();
        }
    }

    public virtual void ResetTrigger()
    {
        TriggerResetter.ResetTrigger();
    }

    protected virtual void ReadyToChangeBrickCount()
    {
        ChangeBrickCount?.Invoke(_deltaBricks);
    }

    protected abstract void OnEnter();
}