using UnityEngine;
using Zenject;

public class BrickCellsFilledChanger : MonoBehaviour
{
    [SerializeField] private Brick _brickPrefab;
    [SerializeField] private Transform _parent;

    private BrickCell[] _brickCells;

    [Inject]
    private void Construct(BrickCell[] brickCells)
    {
        _brickCells = brickCells;
    }

    private void Awake()
    {
        for (int i = 0; i < _brickCells.Length; i++)
        {
            AddBrick(_brickCells[i]);
        }
    }

    private void OnDestroy()
    {
        for (int i = 0; i < _brickCells.Length; i++)
        {
            _brickCells[i].BrickFell -= OnBrickFell;
        }
    }

    private void OnBrickFell(int column, int number)
    {
        for (int i = 0; i < _brickCells.Length; i++)
        {
            if (_brickCells[i].Column == column)
            {
                if (_brickCells[i].Number > number)
                {
                    _brickCells[i].TryDropBrick();
                }
            }
        }
    }

    private void AddBrick(BrickCell brickCell)
    {
        brickCell.BrickFell += OnBrickFell;
        var brick = Instantiate(_brickPrefab, _parent);
        brick.transform.position += brickCell.Position;
        brick.transform.rotation = _brickPrefab.transform.rotation;
        brickCell.AddBrick(brick);
    }
}