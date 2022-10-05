using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BricksCountNulled : MonoBehaviour
{
    [Inject] private readonly IEnumerable<BrickCell> _brickCells;
    [Inject] private Finish _finish;

    private void OnEnable()
    {
        _finish.PlayerFinish += OnPlayerFinish;
    }

    private void OnDisable()
    {
        _finish.PlayerFinish -= OnPlayerFinish;
    }

    private void OnPlayerFinish()
    {
        foreach (var brickCell in _brickCells)
        {
            if (brickCell != null)
            {
                brickCell.RemoveBrick();
            }
        }
    }
}
