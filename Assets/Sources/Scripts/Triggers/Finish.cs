using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class Finish : MonoBehaviour
{
    [Inject] private BricksCounter _bricksCounter;

    public event UnityAction<int> PlayerFinish;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out CharacterMovier characterMovier))
        {
            var bricksCount = _bricksCounter.CountBricks();
            PlayerFinish?.Invoke(bricksCount);
        }
    }
}
