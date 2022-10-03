using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class OnStartDeactivator : MonoBehaviour
{
    [Inject] private RunStarter _runStarter;

    private void OnEnable()
    {
        _runStarter.RunStarted += OnRunStarted;
    }

    private void OnDisable()
    {
        _runStarter.RunStarted -= OnRunStarted;
    }

    private void OnRunStarted()
    {
        gameObject.SetActive(false);
    }
}
