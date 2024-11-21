using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnInterval = 2f;

    private Coroutine _spawnCoroutine;

    private void Start()
    {
        _spawnCoroutine = StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        bool isRunning = true;
        
        while (isRunning)
        {
            Transform randomSpawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            GameObject enemy = Instantiate(_enemyPrefab, randomSpawnPoint.position, Quaternion.identity);
            
            if (enemy.TryGetComponent(out EnemyMover enemyMover))
            {
                Vector3 spawnDirection = randomSpawnPoint.forward;
                enemyMover.SetDirection(spawnDirection);
            }
            
            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    private void OnDestroy()
    {
        if (_spawnCoroutine != null)
        {
            StopCoroutine(_spawnCoroutine);
        }
    }
}
