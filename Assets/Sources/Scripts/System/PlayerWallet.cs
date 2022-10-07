using System;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class PlayerWallet : MonoBehaviour
{
    [Inject] private RunResultCalculator _runResultCalculator;

    public float Money { get; private set; } = 10000;

    public event UnityAction<float> PlayerMoneyChaged;

    private void OnEnable()
    {
        _runResultCalculator.MoneyEarned += OnMoneyEarned;
        PlayerMoneyChaged?.Invoke(Money);
    }

    private void OnDisable() 
    {
        _runResultCalculator.MoneyEarned -= OnMoneyEarned;
    }

    public bool TryMakePurchase(float neededMoney)
    {
        if (Money >= neededMoney)
        {
            ChangePlayerMoney(neededMoney * (-1));
            return true;
        }

        return false;
    }

    private void OnMoneyEarned(float earnedMoney)
    {
        ChangePlayerMoney(earnedMoney);
    }

    private void ChangePlayerMoney(float deltaMoney)
    {
        Money += deltaMoney;
        Money = (float)Math.Round(Money, 1);
        PlayerMoneyChaged?.Invoke(Money);
    }
}
