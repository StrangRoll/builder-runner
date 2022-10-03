using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(WorldInputRoot))]
public class RunStarter : MonoBehaviour
{
    private bool _isRunStarted = false;
    private WorldInputRoot _root;

    public event UnityAction RunStarted;

    private void OnEnable()
    {
        _root = GetComponent<WorldInputRoot>();
        _root.Start += OnStart;
    }

    private void OnDisable()
    {
        _root.Start += OnStart;
    }

    private void OnStart()
    {
        if (_isRunStarted == false)
        {
            _isRunStarted = true;
            RunStarted?.Invoke();
        }
    }
}
