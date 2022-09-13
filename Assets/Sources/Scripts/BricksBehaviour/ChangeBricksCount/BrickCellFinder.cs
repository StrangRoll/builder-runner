using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class BrickCellFinder 
{
    [Inject] private readonly IEnumerable<BrickCell> _brickCells;

    public float GetHighestBrickHight()
    {
        var brickCell = _brickCells.LastOrDefault(brickCell => brickCell.IsFill == true);

        if (brickCell == null)
        {
            brickCell = _brickCells.First();
        }

        return brickCell.Position.y;
    } 
}
