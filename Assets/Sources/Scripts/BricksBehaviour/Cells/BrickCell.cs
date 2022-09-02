using UnityEngine;

public class BrickCell
{
    public readonly Vector3 Position;
    public readonly int Column;
    public readonly int Number;
    public bool IsFill { get; private set; }

    public BrickCell(Vector3 position, int column, int number)
    {
        Position = position;
        Column = column;
        Number = number;
        IsFill = false;
    }
}
