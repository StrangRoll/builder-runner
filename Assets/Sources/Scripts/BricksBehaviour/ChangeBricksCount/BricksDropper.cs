using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class BricksDropper : MonoBehaviour
{
    [Inject] private readonly IEnumerable<BrickCell> _brickCells;

    private void OnEnable()
    {
        foreach (var brickCell in _brickCells)
        {
            brickCell.BrickFell += OnBrickFell;
        }
    }

    private void OnDisable()
    {
        foreach (var brickCell in _brickCells)
        {
            brickCell.BrickFell -= OnBrickFell;
        }
    }

    private void OnBrickFell(int column, int number)
    {
        foreach (var brickCell in _brickCells)
        {
            if (brickCell.Column == column)
            {
                if (brickCell.Number > number)
                {
                    brickCell.TryDropBrick();
                }
            }
        }
    }
}