using UnityEngine;
using Zenject;

public class CharacterPositionReset : MonoBehaviour
{
    private Vector3 _startPosition;

    [Inject] private WorldInputRoot _worldInputRoot;

    private void Awake()
    {
        _startPosition = transform.position;
    }

    private void OnEnable()
    {
        _worldInputRoot.LevelEnded += OnLevelEnded;
    }

    private void OnDisable()
    {
        _worldInputRoot.LevelEnded -= OnLevelEnded;
    }

    private void OnLevelEnded()
    {
        transform.position = _startPosition;
    }
}
