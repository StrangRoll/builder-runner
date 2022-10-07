using System;
using UnityEngine.Events;
using Zenject;

public abstract class Modifier 
{
    private float _increaseStep = 0.1f;
    private float _priceMultiplier = 1.1f;

    [Inject] private PlayerWallet _playerWallet;

    public float ImprovementPrice { get; private set; } = 100;
    public float ModifierValue { get; private set; } = 1.0f;

    public event UnityAction ModifierValueChanged;
    public event UnityAction ModifierPriceChanged;

    public void BuyNextLevel()
    {
        if (_playerWallet.TryMakePurchase(ImprovementPrice))
        {
            OnPurchaseMade();
        }
    }

    private void OnPurchaseMade()
    {
        ImprovementPrice *= _priceMultiplier;
        ImprovementPrice = (float)Math.Round(ImprovementPrice, 1);
        ModifierPriceChanged?.Invoke();

        ModifierValue += _increaseStep;
        ModifierValue = (float)Math.Round(ModifierValue, 1);
        ModifierValueChanged?.Invoke();
    }
}
