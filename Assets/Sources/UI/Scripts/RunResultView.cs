using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class RunResultView : MonoBehaviour
{
    [SerializeField] private TMP_Text _brickResultText;
    [SerializeField] private TMP_Text _earnedMoneyResultText;
    [SerializeField] private TMP_Text _playerMoneyResultText;

    [Inject] private RunResultCalculator _runResultCalculator;

    private void OnEnable()
    {
        _runResultCalculator.BrickResultDone += OnBrickResultDone;
        _runResultCalculator.EarnedMoneyResultDone += OnEarnedMoneyResultDone;
    }

    private void OnDisable()
    {
        _runResultCalculator.BrickResultDone -= OnBrickResultDone;
        _runResultCalculator.EarnedMoneyResultDone -= OnEarnedMoneyResultDone;
    }

    private void OnBrickResultDone(float bricks, float bricksModifier, float collectedBricks)
    {
        _brickResultText.text = bricks.ToString() + " X " + bricksModifier.ToString() + " = " + collectedBricks.ToString();
    }

    private void OnEarnedMoneyResultDone(float bricks, float priceModifier, float earnedMoney)
    {
        _earnedMoneyResultText.text = bricks.ToString() + " X " + priceModifier.ToString() + " = " + earnedMoney.ToString();
    }
}
