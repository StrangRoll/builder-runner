using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class EndRunBrickModifierView : MonoBehaviour
{
    [SerializeField] private Button _brickCountModifierButton;
    [SerializeField] private TMP_Text _brickCountModifierText;

    [Inject] private EndRunBrickModifier _brickModifier;

    private void OnEnable()
    {
        _brickModifier.ModifierValueChanged += OnModifierValueChanged;
        _brickCountModifierButton.onClick.AddListener(_brickModifier.BuyNextLevel);
        OnModifierValueChanged();
    }

    private void OnDisable()
    {
        _brickModifier.ModifierValueChanged -= OnModifierValueChanged;
        _brickCountModifierButton.onClick.RemoveListener(_brickModifier.BuyNextLevel);
    }

    private void OnModifierValueChanged()
    {
        _brickCountModifierText.text = "X"+_brickModifier.ModifierValue.ToString();
    }
}
