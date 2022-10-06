using TMPro;
using UnityEngine;
using Zenject;

public class PlayerWalletView : MonoBehaviour
{
    [SerializeField] private TMP_Text _PlayerMoneyText;

    [Inject] private PlayerWallet _playerWallet;

    private void OnEnable()
    {
        _playerWallet.PlayerMoneyChaged += OnPlayerMoneyChaged;
    }

    private void OnDisable()
    {
        _playerWallet.PlayerMoneyChaged -= OnPlayerMoneyChaged;
    }

    private void OnPlayerMoneyChaged(float newValue)
    {
        _PlayerMoneyText.text = newValue.ToString() + "₲";
    }
}
