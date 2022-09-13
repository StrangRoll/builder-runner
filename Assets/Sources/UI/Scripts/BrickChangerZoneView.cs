using TMPro;
using UnityEngine;

public class BrickChangerZoneView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private BrickChangerZoneTrigger _brickCountChanger;

    private void OnEnable()
    {
        _brickCountChanger.SetDeltaBrick += OnSetDeltaBrick;
    }

    private void OnDisable()
    {
        _brickCountChanger.SetDeltaBrick += OnSetDeltaBrick;
    }

    private void OnSetDeltaBrick(int deltaBrick)
    {
        if (deltaBrick > 0)
        {
            _text.text = $"+{deltaBrick}";
        }
        else
        {
            _text.text = deltaBrick.ToString();
        }
    }
}
