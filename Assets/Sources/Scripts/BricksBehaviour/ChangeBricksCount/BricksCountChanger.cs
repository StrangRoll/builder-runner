using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class BricksCountChanger : MonoBehaviour
{
    [SerializeField] private Brick _brickPrefab;
    [SerializeField] private Transform _parent;

    [Inject] private readonly IEnumerable<BrickCell> _brickCells;
    [Inject] private readonly IEnumerable<BricksCountChangerTrigger> _triggers;

    private void Awake()
    {
        foreach (var trigger in _triggers)
        {
            trigger.ChangeBrickCount += OnChangeBrickCount;
        }
    }

    private void OnDestroy()
    {
        foreach (var trigger in _triggers)
        {
            trigger.ChangeBrickCount -= OnChangeBrickCount;
        }
    }

    private void OnChangeBrickCount(int deltaBricks)
    {
        if (deltaBricks > 0)
        {
            for (int i = 0; i < deltaBricks; i++)
            {
                AddNewBrick();
            }
        }
        else
        {
            deltaBricks *= -1;

            for (int i = 0; i < deltaBricks; i++)
            {
                RemoveBrick();
            }
        }
    }

    private void AddNewBrick()
    {
        var brickCell = _brickCells.FirstOrDefault(brickCell => brickCell.IsFill == false);

        if (brickCell != null)
        {
            var brick = Instantiate(_brickPrefab, _parent);
            brick.transform.position += brickCell.Position;
            brick.transform.rotation = _brickPrefab.transform.rotation;
            brickCell.AddBrick(brick);
        }
    }

    private void RemoveBrick()
    {
        var brickCell = _brickCells.LastOrDefault(brickCell => brickCell.IsFill == true);

        if (brickCell != null)
        {
            brickCell.RemoveBrick();
        }
    }
}
