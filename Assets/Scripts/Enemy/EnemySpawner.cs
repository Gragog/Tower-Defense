using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [Tooltip("Enemy to spawn")]
    public GameObject enemy;

    [Tooltip("How many enemies to spawn")]
    public int amount = 5;

    [Tooltip("Time before first enemy spawns")]
    public float startDelay = 5f;

    [Tooltip("Delay between each enemy")]
    public float delay = 0.5f;

    int enemyCount = 0;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, delay);
    }

    void SpawnEnemy()
    {
        Instantiate(enemy, transform.position, Quaternion.identity, transform);
        enemyCount++;

        if (enemyCount >= amount)
        {
            CancelInvoke("SpawnEnemy");
        }
    }
}
