using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BrickChangerTriggerActivator : MonoBehaviour
{
    [Inject] private readonly IEnumerable<BricksCountChangerTrigger> _triggers;
    [Inject] private WorldInputRoot _worldInputRoot;

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
        foreach (var trigger in _triggers)
        {
            if (trigger.gameObject.activeSelf == false)
            {
                trigger.ResetTrigger();
            }
        }
    }
}
