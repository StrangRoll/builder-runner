using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BrickPriceModifierView : MonoBehaviour
{
    [SerializeField] private Button _brickPriceModifierButton;
    [SerializeField] private TMP_Text _brickPriceModifierText;

    [Inject] private BrickPriceModifier _modifier;

    private void Awake()
    {
        OnBrickPriceChanged();
    }

    private void OnBrickPriceChanged()
    {
        _brickPriceModifierText.text = _modifier.BrickPrice.ToString() + " ₲";
    }
}
