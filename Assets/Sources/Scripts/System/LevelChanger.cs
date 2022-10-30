using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private LevelStorage _levelsStorage;

    private Level _previousLevel;

    private void OnEnable()
    {
        _levelsStorage.ChangeLevel += OnChangeLevel;
    }

    private void OnDisable()
    {
        _levelsStorage.ChangeLevel -= OnChangeLevel;
    }

    private void OnChangeLevel(Level level)
    {
        level.gameObject.SetActive(true);

        if (_previousLevel != null)
        {
            _previousLevel.gameObject.SetActive(false);
        }

        _previousLevel = level;
    }
}
