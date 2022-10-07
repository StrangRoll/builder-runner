using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BrickPriceModifierView : MonoBehaviour
{
    [SerializeField] private Button _brickPriceModifierButton;
    [SerializeField] private TMP_Text _brickPriceModifierText;
    [SerializeField] private TMP_Text _upgradeCostText;

    [Inject] private BrickPriceModifier _priceModifier;

    private void OnEnable()
    {
        _priceModifier.ModifierValueChanged += OnModifierValueChanged;
        _priceModifier.ModifierPriceChanged += OnModifierPriceChanged;
        _brickPriceModifierButton.onClick.AddListener(_priceModifier.BuyNextLevel);
        OnModifierValueChanged();
        OnModifierPriceChanged();
    }

    private void OnDisable()
    {
        _priceModifier.ModifierValueChanged -= OnModifierValueChanged;
        _priceModifier.ModifierPriceChanged -= OnModifierPriceChanged;
        _brickPriceModifierButton.onClick.RemoveListener(_priceModifier.BuyNextLevel);
    }

    private void OnModifierValueChanged()
    {
        _brickPriceModifierText.text = _priceModifier.ModifierValue.ToString() + " ₲";
    }

    private void OnModifierPriceChanged()
    {
        _upgradeCostText.text = _priceModifier.ImprovementPrice.ToString() + "  ₲";

    }
}
