using UnityEngine;
using UnityEngine.Events;

public class BrickCell
{
    public readonly Vector3 Position;
    public readonly int Column;
    public readonly int Number;

    private Brick _brick;

    public bool IsFill { get; private set; }

    public event UnityAction<int, int> CellNulled;

    public BrickCell(Vector3 position, int column, int number)
    {
        Position = position;
        Column = column;
        Number = number;
        IsFill = false;
    }

    public void AddBrick(Brick brick)
    {
        _brick = brick;
        IsFill = true;
        _brick.BrickRemoved += OnBrickRemoved;
    }

    public void DropBrick()
    {
        _brick.OnEnter(_brick);
    }

    private void OnBrickRemoved()
    {
        _brick.BrickRemoved -= OnBrickRemoved;
        _brick = null;
        IsFill = false;
        CellNulled?.Invoke(Column, Number);
    }
}
