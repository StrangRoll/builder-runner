using UnityEngine;
using UnityEngine.Events;

public class BrickCell
{
    public readonly Vector3 Position;
    public readonly int Column;
    public readonly int Number;

    private Brick _brick;

    public bool IsFill { get; private set; }

    public event UnityAction<int, int> BrickFell;
    public event UnityAction<Brick> BrickAdded;
    public event UnityAction<Brick> BrickRemoved;

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
        _brick.BrickFell += OnBrickFell;
        BrickAdded?.Invoke(_brick);
    }

    public void RemoveBrick()
    {
        if (_brick != null)
        {
            BrickRemoved?.Invoke(_brick);
            _brick.Kill();
            ResetCell();
        }
    }

    public void TryDropBrick()
    {
        if (_brick != null)
        {
            _brick.Fall();
            ResetCell();
        }
    }

    private void OnBrickFell()
    {
        ResetCell();
        BrickFell?.Invoke(Column, Number);
    }

    private void ResetCell()
    {
        _brick.BrickFell -= OnBrickFell;
        _brick = null;
        IsFill = false;
    }
}
