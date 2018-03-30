using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave", menuName = "Enemy/Wave")]
public class Wave : ScriptableObject {

    [Tooltip("Enemy to spawn")]
    public GameObject enemy;

    [Tooltip("Amount of enemies")]
    public int enemyCount;

    [Tooltip("Delay between each enemy")]
    public float delay = 0.5f;

    [Tooltip("Delay after wave has spawned")]
    public float postDelay = 2f;

    [Header("Use this to adjust time for special waves (like bosses)")]
    [Tooltip("Delay before wave is spawned")]
    public float preDelay = 0f;
}
