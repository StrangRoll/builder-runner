using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class PlayerWallet : MonoBehaviour
{
    [Inject] private RunResultCalculator _runResultCalculator;

    public float Money { get; private set; } = 0;

    public event UnityAction<float> PlayerMoneyChaged;

    private void OnEnable()
    {
        _runResultCalculator.MoneyEarned += OnMoneyEarned;
    }

    private void OnDisable()
    {
        _runResultCalculator.MoneyEarned -= OnMoneyEarned;
    }

    private void OnMoneyEarned(float earnedMoney)
    {
        Money += earnedMoney;
        PlayerMoneyChaged?.Invoke(Money);
    }
}
