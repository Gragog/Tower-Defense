using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Tooltip("Time before first enemy spawns")]
    public float startDelay = 5f;

    public List<Wave> waves;

    int waveCount = 0;
    private bool waveIsSpawning = false;

    void Start()
    {
        SpawnWaves();
    }

    IEnumerator SpawnEnemy(Wave wave)
    {
        waveIsSpawning = true;

        if (waveCount == 0) yield return new WaitForSeconds(startDelay);

        for (int i = 0; i < wave.enemyCount; i++)
        {
            Instantiate(wave.enemy, transform.position, Quaternion.identity, transform);

            yield return new WaitForSeconds(wave.delay);
        }

        yield return new WaitForSeconds(wave.postDelay);
        waveCount++;
        waveIsSpawning = false;

        if (waveCount < waves.Count) StartCoroutine(LetMeSpawnNextWave(wave.postDelay));

        yield break;
    }

    IEnumerator LetMeSpawnNextWave(float waitFor)
    {
        yield return new WaitForSeconds(waitFor);

        StartCoroutine(SpawnEnemy(waves[waveCount]));
    }

    void SpawnWaves()
    {
        StartCoroutine(SpawnEnemy(waves[waveCount]));
    }

    /* void Update()
    {
        if (! waveIsSpawning)
        {
            SpawnNextWave();
        }
    } */
}
