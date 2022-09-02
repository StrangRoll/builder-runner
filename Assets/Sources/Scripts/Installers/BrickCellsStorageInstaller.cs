using UnityEngine;
using Zenject;

public class BrickCellsStorageInstaller : MonoInstaller
{
    [SerializeField] private int _maxCellsCount;
    [SerializeField] private int _cellsPerSide;
    [SerializeField] private float _brickWidth;
    [SerializeField] private float _brickHeight;

    private int _cellsPerLevel;
    private int _sideCount = 2;
    private int _centrerCell = 1;
    BrickCell[] _brickCells;


    public override void InstallBindings()
    {
        _cellsPerLevel = _cellsPerSide * _sideCount + _centrerCell;
        _brickCells = new BrickCell[_maxCellsCount];
        var hightLevel = 0;
        var currentColumn = 0;

        for (int i = 0; i < _maxCellsCount; i++)
        {
            var position = new Vector3((_sideCount * -1 + currentColumn) * _brickWidth, hightLevel * _brickHeight, 0);
            _brickCells[i] = new BrickCell(position , currentColumn, hightLevel);
            currentColumn++;

            if (currentColumn >= _cellsPerLevel)
            {
                currentColumn = 0;
                hightLevel++;
            }
        }

        Container
            .Bind<BrickCell[]>()
            .FromInstance(_brickCells);
    }
}
