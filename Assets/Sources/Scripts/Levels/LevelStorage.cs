using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class LevelStorage : MonoBehaviour
{
    [Inject] private WorldInputRoot _worldInputRoot;

    private List<StandartLevel> _standartLevels;
    private FinalLevel _finalLevel;
    private StandartLevel _nextLevel;

    public event UnityAction<Level> ChangeLevel;

    private void Awake()
    {
        _standartLevels = new List<StandartLevel>(GetComponentsInChildren<StandartLevel>());

        foreach (var level in _standartLevels)
        {
            level.gameObject.SetActive(false);
        }

        if (GetComponentsInChildren<FinalLevel>().Length != 1)
        {
            Debug.LogError("Incorrect finish level count!");
        }

        _finalLevel = GetComponentInChildren<FinalLevel>();
        _finalLevel.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _worldInputRoot.LevelEnded += OnLevelEnded;
    }

    private void Start()
    {
        OnLevelEnded();
    }

    private void OnDisable()
    {
        _worldInputRoot.LevelEnded -= OnLevelEnded;
    }

    private void OnLevelEnded()
    {
        if (_standartLevels.Count > 0)
        {
            var index = Random.Range(0, _standartLevels.Count);
            _nextLevel = _standartLevels[index];
            _standartLevels.RemoveAt(index);
            ChangeLevel.Invoke(_nextLevel);
        }
        else
        {
            ChangeLevel?.Invoke(_finalLevel);
        }
    }
}
