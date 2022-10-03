using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Animator))]

public class CharacterAnimationController : MonoBehaviour
{
    [Inject] private RunStarter _runStarter;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _runStarter.RunStarted += OnRunStarted;
    }

    private void OnDisable()
    {
        _runStarter.RunStarted -= OnRunStarted;
    }

    public void OnRunStarted()
    {
        _animator.SetTrigger(CharacterAnimatorParameters.RunStartTrigger);
    }
}

public static class CharacterAnimatorParameters
{
    public static string RunStartTrigger = "RunStarted";
}
