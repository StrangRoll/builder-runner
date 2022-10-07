using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BrickPriceModifierView : MonoBehaviour
{
    [SerializeField] private Button _brickPriceModifierButton;
    [SerializeField] private TMP_Text _brickPriceModifierText;

    [Inject] private BrickPriceModifier _priceModifier;

    private void OnEnable()
    {
        _priceModifier.ModifierValueChanged += OnModifierValueChanged;
        _brickPriceModifierButton.onClick.AddListener(_priceModifier.BuyNextLevel);
        OnModifierValueChanged();
    }

    private void OnDisable()
    {
        _priceModifier.ModifierValueChanged -= OnModifierValueChanged;
        _brickPriceModifierButton.onClick.RemoveListener(_priceModifier.BuyNextLevel);
    }

    private void OnModifierValueChanged()
    {
        _brickPriceModifierText.text = _priceModifier.ModifierValue.ToString() + " ₲";
    }
}
