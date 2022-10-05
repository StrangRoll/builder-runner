using UnityEngine;
using Zenject;

[RequireComponent(typeof(Animator))]

public class CharacterAnimationController : MonoBehaviour
{
    [Inject] private RunStarter _runStarter;
    [Inject] private Finish _finish;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _runStarter.RunStarted += OnRunStarted;
        _finish.PlayerFinish += OnPlayerFinish;
    }

    private void OnDisable()
    {
        _runStarter.RunStarted -= OnRunStarted;
        _finish.PlayerFinish -= OnPlayerFinish;
    }

    private void OnRunStarted()
    {
        _animator.SetTrigger(CharacterAnimatorParameters.RunStartTrigger);
    }

    private void OnPlayerFinish()
    {
        _animator.SetTrigger(CharacterAnimatorParameters.RunEndedTrigger);
    }
}

public static class CharacterAnimatorParameters
{
    public static string RunStartTrigger = "RunStarted";
    public static string RunEndedTrigger = "RunEnded";
}
