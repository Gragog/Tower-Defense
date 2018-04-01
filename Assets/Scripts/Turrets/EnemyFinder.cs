using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFinder : MonoBehaviour {

    public string enemyTag = "Enemy";

    public float startTime = 1f;
    public float frequency = .5f;

    public static GameObject[] enemies;

    void Start () {
        enemies = new GameObject[0];
        InvokeRepeating("UpdateEnemyList", startTime, frequency);
	}
	
	void UpdateEnemyList () {
        enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        // Debug.Log("counted " + enemies.Length + " enemies");
    }
}
