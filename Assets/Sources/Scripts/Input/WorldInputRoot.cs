using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class WorldInputRoot : MonoBehaviour
{
    public event Action Start;

    [Inject] private RunStartButton _startButton;

    private void OnEnable()
    {
        _startButton.StratButtonPressed += OnStartButtonPress;
    }

    private void OnDisable()
    {
        _startButton.StratButtonPressed -= OnStartButtonPress;
    }

    private void OnStartButtonPress()
    {
        Start?.Invoke();
    }
}
