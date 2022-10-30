using UnityEngine;
using Zenject;

[RequireComponent(typeof(CanvasGroup))]

public class WinMenuActivationChanger : MonoBehaviour
{
    [Inject] private Finish _finish;
    [Inject] private WorldInputRoot _worldInput;

    private CanvasGroup _canvasGroup;

    private void OnEnable()
    {
        _finish.PlayerFinish += OnPlayerFinish;
        _worldInput.LevelEnded += OnLevelEnded; 
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnDisable()
    {
        _finish.PlayerFinish -= OnPlayerFinish;
        _worldInput.LevelEnded -= OnLevelEnded;
    }

    private void OnPlayerFinish()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }

    private void OnLevelEnded()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }
}
