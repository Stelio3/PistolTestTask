using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : Singleton<EnemySpawner>
{
    [SerializeField] private EnemiesSpawner_SO _spawner;
    private List<double> _cumulativeWeights = new List<double>();
    private List<SpawnProbability> _enemies = new List<SpawnProbability>();
    private List<GameObject> _enemiesSpawned = new List<GameObject>();

    private float _minDistance = 3;
    private float _maxDistance = 10;
    private float _enemiesMaxDisplayed = 25;
    private float _enemiesSpawnFreq = 1.2f;
    private float lastEnemy;
    private Vector2 _spawnPosition;

    private void Awake()
    {
        _enemies = _spawner.enemy.ToList();
        CalculateWeights();
    }
    private void Update()
    {
        SpawnEnemy();
    }

    private int GetRandomEnemyIndex()
    {
        double randomValue = Random.Range(0f, 1f) * _cumulativeWeights[_cumulativeWeights.Count - 1];
        int index = _cumulativeWeights.BinarySearch(randomValue);
        if (index < 0)
        {
            index = ~index;
        }
        return index;
    }

    private void CalculateWeights()
    {
        double sum = 0f;
        foreach (SpawnProbability enemy in _enemies)
        {
            sum += enemy.Chance;
            _cumulativeWeights.Add(sum);
        }
    }
    private bool CheckCalculateSpawnPosition()
    {
        if(_enemiesSpawned.Count < _enemiesMaxDisplayed && lastEnemy + _enemiesSpawnFreq < Time.realtimeSinceStartup)
        {
            lastEnemy = Time.realtimeSinceStartup;

            Vector2 offset = Random.insideUnitCircle.normalized * Random.Range(_minDistance, _maxDistance);
            _spawnPosition = PlayerController.Instance.transform.position + new Vector3(offset.x, offset.y, 0);

            return true;
        }
        return false;
    }

    private void SpawnEnemy()
    {
        CheckDestroyFarEnemy();

        if (!CheckCalculateSpawnPosition())
            return;

        SpawnProbability randomEnemy = _enemies[GetRandomEnemyIndex()];

        GameObject enemy = Instantiate(randomEnemy.prefab, _spawnPosition, Quaternion.identity, transform);
        _enemiesSpawned.Add(enemy);
    }
    public void DestroyEnemy(GameObject enemy)
    {
        _enemiesSpawned.Remove(enemy);
        Destroy(enemy);
    }
    private void CheckDestroyFarEnemy()
    {
        var toDestroy = new List<GameObject>();
        List<GameObject> enemiesAux = new List<GameObject>();

        enemiesAux.AddRange(_enemiesSpawned);
        foreach (GameObject enemy in enemiesAux)
        {
            var distancia = Vector3.Distance(enemy.transform.position, PlayerController.Instance.transform.position);
            if (distancia > 40)
            {
                toDestroy.Add(enemy);
            }
        }
        foreach (GameObject enemy in toDestroy)
        {
            DestroyEnemy(enemy);
        }
    }
}
