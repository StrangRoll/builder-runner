using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;
using Zenject;

public class BricksCounter
{
    [Inject] private readonly IEnumerable<BrickCell> _brickCells;

    public int CountBricks()
    {
        return _brickCells.Count(brickCell => brickCell.IsFill == true);
    }
}
