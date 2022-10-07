using UnityEngine;
using UnityEngine.Events;
using Zenject;

public abstract class Modifier 
{
    protected float _increaseStep = 0.1f;
    protected float _priceMultiplier = 1.1f;
    protected float _improvementPrice = 100;

    [Inject] private PlayerWallet _playerWallet;

    public float ModifierValue { get; private set; } = 1.0f;

    public event UnityAction ModifierValueChanged;

    public void BuyNextLevel()
    {
        if (_playerWallet.TryMakePurchase(_improvementPrice))
        {
            OnPurchaseMade();
        }
    }

    private void OnPurchaseMade()
    {
        _improvementPrice *= _priceMultiplier;
        ModifierValue += _increaseStep;
        ModifierValueChanged?.Invoke();
    }
}
