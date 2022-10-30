using UnityEngine;
using Zenject;

[RequireComponent(typeof(CanvasGroup))]
public class StartMenuActivationChanger : MonoBehaviour
{
    [Inject] private WorldInputRoot _worldInput;

    private CanvasGroup _canvasGroup;

    private void OnEnable()
    {
        _worldInput.RunStarted += OnRunStarted;
        _worldInput.LevelEnded += OnLevelEnded;
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnDisable()
    {
        _worldInput.RunStarted -= OnRunStarted;
        _worldInput.LevelEnded -= OnLevelEnded;
    }

    private void OnRunStarted()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }

    private void OnLevelEnded()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }
}
