using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class EndRunBrickModifierView : MonoBehaviour
{
    [SerializeField] private Button _modifierButton;
    [SerializeField] private TMP_Text _modifierText;
    [SerializeField] private TMP_Text _upgradeCostText;

    [Inject] private EndRunBrickModifier _brickModifier;

    private void OnEnable()
    {
        _brickModifier.ModifierValueChanged += OnModifierValueChanged;
        _brickModifier.ModifierPriceChanged += OnModifierPriceChanged;
        _modifierButton.onClick.AddListener(_brickModifier.BuyNextLevel);
        OnModifierValueChanged();
        OnModifierPriceChanged();
    }

    private void OnDisable()
    {
        _brickModifier.ModifierValueChanged -= OnModifierValueChanged;
        _brickModifier.ModifierPriceChanged -= OnModifierPriceChanged;
        _modifierButton.onClick.RemoveListener(_brickModifier.BuyNextLevel);
    }

    private void OnModifierValueChanged()
    {
        _modifierText.text = "X"+_brickModifier.ModifierValue.ToString();
    }

    private void OnModifierPriceChanged()
    {
        _upgradeCostText.text = _brickModifier.ImprovementPrice.ToString() + "  ₲";
    }
}
