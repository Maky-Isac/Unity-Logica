using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform playerTransform;
    public float spawnRate = 2f;
    public float spawnDistance = 12f;
    private float timer;
    
    void Update()
    {
        if (playerTransform == null) return;
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnEnemy();
            timer = 0;
        }
    }

    void SpawnEnemy()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector3 spawnPosition = playerTransform.position + (Vector3)(randomDirection * spawnDistance);

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
