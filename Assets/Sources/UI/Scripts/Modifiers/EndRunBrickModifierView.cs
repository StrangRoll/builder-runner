using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class EndRunBrickModifierView : MonoBehaviour
{
    [SerializeField] private Button _brickCountModifierButton;
    [SerializeField] private TMP_Text _brickCountModifierText;

    [Inject] private EndRunBrickModifier _modifier;

    private void Awake()
    {
        OnBrickCountModifierChanged();
    }

    private void OnBrickCountModifierChanged()
    {
        _brickCountModifierText.text = "X"+_modifier.BrickCountModifier.ToString();
    }
}
