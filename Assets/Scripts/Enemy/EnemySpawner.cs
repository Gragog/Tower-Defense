using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Tooltip("Time before first enemy spawns")]
    public float startDelay = 5f;

    public List<Wave> waves;

    int waveCount = 0;
    bool waveIsSpawning = false;

    [Header("Text")]
    [Space(5)]
    public Text currentWaveText;
    public Text spawnsInWaveText;
    public Text timeToNextWaveText;
    float waveCountdown;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        waveCountdown = startDelay;
        yield return new WaitForSeconds(startDelay);

        foreach (Wave wave in waves)
        {
            waveCountdown = wave.preDelay;
            yield return new WaitForSeconds(wave.preDelay);

            waveCount++;
            currentWaveText.text = "Wave " + waveCount.ToString() + " / " + waves.Count.ToString();

            waveIsSpawning = true;
            for (int i = 0; i < wave.enemyCount; i++)
            {
                spawnsInWaveText.text = "Enemy " + (i + 1).ToString() + " / " + wave.enemyCount.ToString();

                Instantiate(wave.enemy, transform.position, Quaternion.identity, transform);

                yield return new WaitForSeconds(wave.delay);
            }
            waveIsSpawning = false;

            waveCountdown = wave.postDelay;
            yield return new WaitForSeconds(wave.postDelay);
        }
    }

    void Update()
    {
        timeToNextWaveText.text = "Wave is spawning";

        if (!waveIsSpawning && waveCount < waves.Count)
        {
            timeToNextWaveText.text = "Waiting for: " + waveCountdown.ToString("0.0");
            waveCountdown -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
