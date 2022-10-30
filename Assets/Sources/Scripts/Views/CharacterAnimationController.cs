using UnityEngine;
using Zenject;

[RequireComponent(typeof(Animator))]

public class CharacterAnimationController : MonoBehaviour
{
    [Inject] private WorldInputRoot _worldInput;
    [Inject] private Finish _finish;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _worldInput.RunStarted += OnRunStarted;
        _worldInput.LevelEnded += OnLevelEnded;
        _finish.PlayerFinish += OnPlayerFinish;
    }

    private void OnDisable()
    {
        _worldInput.RunStarted -= OnRunStarted;
        _worldInput.LevelEnded -= OnLevelEnded;
        _finish.PlayerFinish -= OnPlayerFinish;
    }

    private void OnLevelEnded()
    {
        _animator.SetTrigger(CharacterAnimatorParameters.RunRestartedTrigger);
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
    public static string RunRestartedTrigger = "RunRestarted";
}
