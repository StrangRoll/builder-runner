using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class Finish : MonoBehaviour
{
    [Inject] private BricksCounter _bricksCounter;

    public event UnityAction PlayerFinish;
    public event UnityAction<int> EndBrickCounted;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out CharacterMovier characterMovier))
        {
            var bricksCount = _bricksCounter.CountBricks();
            PlayerFinish?.Invoke();
            EndBrickCounted?.Invoke(bricksCount);
        }
    }
}
