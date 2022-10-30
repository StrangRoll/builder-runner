using TMPro;
using UnityEngine;

[RequireComponent (typeof(BrickChangerZoneTrigger))]
public class BrickChangerZoneView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private BrickChangerZoneTrigger _brickCountChanger;
    private BrickCountChangeTriggerResetter _triggerResetter;

    private void Awake()
    {
        _triggerResetter = new BrickCountChangeTriggerResetter(transform);
    }

    private void OnEnable()
    {
        _brickCountChanger = GetComponent<BrickChangerZoneTrigger>();
        _brickCountChanger.SetDeltaBrick += OnSetDeltaBrick;
    }

    private void OnDisable()
    {
        _brickCountChanger.SetDeltaBrick -= OnSetDeltaBrick;
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
