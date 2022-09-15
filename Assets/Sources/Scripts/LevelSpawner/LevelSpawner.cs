using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField] private SpawnableObject[] _prefabs;
    [SerializeField] private int _startObstaclesCount;

    [Inject] private DiContainer _container;

    private float _unitPerSpawn = 20;
    private List<SpawnableObject> _spawnedObject;

    public event UnityAction<SpawnableObject> ObjectSpawned;
    public event UnityAction<IEnumerable<SpawnableObject>> AllDespawned;

    private void Start()
    {
        _spawnedObject = new List<SpawnableObject>();
        SpawnLevel(_startObstaclesCount);
    }

    public void SpawnLevel(int obstaclesCount)
    {
        var position = Vector3.zero;

        for (int i = 0; i < obstaclesCount; i++)
        {
            position += Vector3.forward * _unitPerSpawn;
            SpawnRandomObject(position);
        }
    }

    private void SpawnRandomObject(Vector3 position)
    {
        var index = Random.Range(0, _prefabs.Length);
        var newObject = _container.InstantiatePrefab(_prefabs[index]).GetComponent<SpawnableObject>();
        newObject.transform.position = position + _prefabs[index].transform.position;
        newObject.transform.rotation = _prefabs[index].transform.rotation;

        _spawnedObject.Add(newObject);
        ObjectSpawned?.Invoke(newObject);
    }

    private void DespawnAllObjects()
    {
        AllDespawned?.Invoke(_spawnedObject);
    }
}
