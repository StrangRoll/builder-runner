using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class RunResultCalculator : MonoBehaviour
{
    [Inject] private Finish _finish;
    [Inject] private EndRunBrickModifier _brickModifier;
    [Inject] private BrickPriceModifier _priceModifier;

    public event UnityAction<float, float, float> BrickResultDone;
    public event UnityAction<float, float, float> EarnedMoneyResultDone;

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
    }
}
