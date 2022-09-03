using UnityEngine;
using Zenject;

public class BrickCellsStorage : MonoBehaviour
{
    [SerializeField] private Brick _brickPrefab;
    [SerializeField] private Transform _parent;

    [Inject] private DiContainer _diContainer;

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
            _brickCells[i].CellNulled += OnCellNulled;
            var brick = _diContainer.InstantiatePrefab(_brickPrefab, _parent).GetComponent<Brick>();
            brick.transform.position += _brickCells[i].Position;
            brick.transform.rotation = _brickPrefab.transform.rotation;
            _brickCells[i].AddBrick(brick);
        }
    }

    private void OnDestroy()
    {
        for (int i = 0; i < _brickCells.Length; i++)
        {
            _brickCells[i].CellNulled -= OnCellNulled;
        }
    }

    private void OnCellNulled(int column, int number)
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
}