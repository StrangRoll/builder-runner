using UnityEngine;
using Zenject;

[RequireComponent(typeof(CanvasGroup))]

public class WinMenuActivationChanger : MonoBehaviour
{
    [Inject] private Finish _finish;

    private CanvasGroup _canvasGroup;

    private void OnEnable()
    {
        _finish.PlayerFinish += OnPlayerFinish;
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnDisable()
    {
        _finish.PlayerFinish -= OnPlayerFinish;
    }

    private void OnPlayerFinish()
    {
        _canvasGroup.alpha = 1;
    }
}
