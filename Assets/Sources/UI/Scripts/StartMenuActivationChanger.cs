using UnityEngine;
using Zenject;

[RequireComponent(typeof(CanvasGroup))]
public class StartMenuActivationChanger : MonoBehaviour
{
    [Inject] private RunStarter _runStarter;

    private CanvasGroup _canvasGroup;

    private void OnEnable()
    {
        _runStarter.RunStarted += OnRunStarted;
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnDisable()
    {
        _runStarter.RunStarted -= OnRunStarted;
    }

    private void OnRunStarted()
    {
        _canvasGroup.alpha = 0;
    }
}
