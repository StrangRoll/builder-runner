using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class RunStartButton : MonoBehaviour, IPointerDownHandler
{
    public event UnityAction StratButtonPressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        StratButtonPressed?.Invoke();
    }
}
