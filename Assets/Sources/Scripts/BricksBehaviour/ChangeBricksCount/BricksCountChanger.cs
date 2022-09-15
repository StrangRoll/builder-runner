using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System.Linq;
using UnityEngine.Events;

public class BricksCountChanger : MonoBehaviour
{
    [SerializeField] private Brick _brickPrefab;
    [SerializeField] private Transform _parent;

    [Inject] private readonly IEnumerable<BrickCell> _brickCells;
    [Inject] private readonly LevelSpawner _levelSpawner;

    private void OnEnable()
    {
        _levelSpawner.ObjectSpawned += OnObjectSpawned;
        _levelSpawner.AllDespawned += OnAllDespawned;
    }

    private void OnDisable()
    {
        _levelSpawner.ObjectSpawned -= OnObjectSpawned;
        _levelSpawner.AllDespawned -= OnAllDespawned;
    }

    private void OnAllDespawned(IEnumerable<SpawnableObject> despawnObjects)
    {
        foreach (var despawnObject in despawnObjects)
        {
            var trigers = despawnObject.GetComponentsInChildren<BricksCountChangerTrigger>();

            foreach (var trigger in trigers)
            {
                trigger.ChangeBrickCount -= OnChangeBrickCount;
            }
        }
    }

    private void OnObjectSpawned(SpawnableObject newObject)
    {
        var trigers = newObject.GetComponentsInChildren<BricksCountChangerTrigger>();

        foreach (var trigger in trigers)
        {
            trigger.ChangeBrickCount += OnChangeBrickCount;
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
