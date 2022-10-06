using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class RunResultCalculator : MonoBehaviour
{
    [Inject] private Finish _finish;
    [Inject] private EndRunBrickModifier _brickModifier;
    [Inject] private BrickPriceModifier _priceModifier;
    [Inject] private PlayerWallet _playerWallet;

    public event UnityAction<float, float, float> BrickResultDone;
    public event UnityAction<float, float, float> EarnedMoneyResultDone;
    public event UnityAction<float, float, float> PlayerMoneyResultDone;
    public event UnityAction<float> MoneyEarned;

    private void OnEnable()
    {
        _finish.EndBrickCounted += OnEndBrickCounted;
    }

    private void OnDisable()
    {
        _finish.EndBrickCounted -= OnEndBrickCounted;
    }

    private void OnEndBrickCounted(int bricks)
    {
        var brickModifier = _brickModifier.BrickCountModifier;
        var collectedBricks = bricks * brickModifier;
        BrickResultDone?.Invoke(bricks, brickModifier, collectedBricks);

        var priceModifier = _priceModifier.BrickPrice;
        var earnedMoney = collectedBricks * priceModifier;
        EarnedMoneyResultDone?.Invoke(collectedBricks, priceModifier, earnedMoney);

        var playerMoney = _playerWallet.Money;
        var newPlayerMoney = playerMoney + earnedMoney;
        PlayerMoneyResultDone?.Invoke(playerMoney, earnedMoney, newPlayerMoney);
        MoneyEarned?.Invoke(newPlayerMoney);
    }
}
