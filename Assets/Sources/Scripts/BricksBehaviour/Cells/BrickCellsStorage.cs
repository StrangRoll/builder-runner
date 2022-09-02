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
            var brick = _diContainer.InstantiatePrefab(_brickPrefab, _parent);
            brick.transform.position += _brickCells[i].Position;
            brick.transform.rotation = _brickPrefab.transform.rotation;
        }
    }
}