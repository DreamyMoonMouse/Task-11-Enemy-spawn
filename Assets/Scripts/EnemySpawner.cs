using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnInterval = 2f;

    private Coroutine spawnCoroutine;

    private void Start()
    {
        spawnCoroutine = StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        bool isRunning = true;
        
        while (isRunning)
        {
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject enemy = Instantiate(enemyPrefab, randomSpawnPoint.position, Quaternion.identity);
            
            if (enemy.TryGetComponent(out EnemyMover enemyMover))
            {
                Vector3 spawnDirection = randomSpawnPoint.forward;
                enemyMover.SetDirection(spawnDirection);
            }
            else
            {
                Debug.Log("Ошибка");
            }
            
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void OnDestroy()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
        }
    }
}
