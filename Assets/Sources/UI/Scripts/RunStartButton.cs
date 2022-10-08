using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RunStartButton : MonoBehaviour
{
    [SerializeField] private Button _runControlButton;

    public event UnityAction RunControlButtonPressed;

    private void OnEnable()
    {
        _runControlButton.onClick.AddListener(OnRunControlButtonPressedClick);
    }

    private void OnDisable()
    {
        _runControlButton.onClick.RemoveListener(OnRunControlButtonPressedClick);
    }

    public void OnRunControlButtonPressedClick()
    {
        RunControlButtonPressed?.Invoke();
    }
}
