using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class LevelStorage : MonoBehaviour
{
    [Inject] private WorldInputRoot _worldInputRoot;

    private IEnumerable<Level> _allLevels;
    private List<Level> _levels;
    private Level _nextLevel;

    public event UnityAction<Level> ChangeLevel;

    private void Awake()
    {
        _allLevels = new List<Level>(GetComponentsInChildren<Level>());

        foreach (var level in _allLevels)
        {
            level.gameObject.SetActive(false);
        }

        ResetLevels();
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
        if (_levels.Count <= 0)
        {
            ResetLevels();
        }

        var index = Random.Range(0, _levels.Count);
        _nextLevel = _levels[index];
        _levels.RemoveAt(index);
        ChangeLevel.Invoke(_nextLevel);
    }

    private void ResetLevels()
    {
        _levels = new List<Level>(_allLevels);
    }
}
