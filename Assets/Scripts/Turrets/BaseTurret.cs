using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTurret: MonoBehaviour {

    [Header("Turret Attributes")]
    public float range = 15f;
    public float damagePerHit = 5f;
    public float attackRate = 1f;
    public float rotationSpeed = 10f;
    [Range(.01f, 10f)][Tooltip("Intervall for refreshing the target.\nHigh attack rate mens a lower refresh Intervall.\n(default: 0.5)")]
    public float refreshTargetIntervall = .5f;

    float attackCountdown;
    protected Transform partToRotate;
    public GameObject target;

    protected void Start()
    {
        attackCountdown = 1f / attackRate;
        InvokeRepeating("UpdateTarget", 0f, refreshTargetIntervall);
    }

    protected abstract void Attack();

    void UpdateTarget()
    {
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in EnemyFinder.enemies)
        {
            if (!enemy) continue;

            float distanceToEnemy = Vector3.SqrMagnitude(enemy.transform.position - transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= (range * range))
        {
            target = nearestEnemy;
            return;
        }

        target = null;
    }

    void Update()
    {
        attackCountdown -= Time.deltaTime;

        if (target != null)
        {
            // Rotate the Head of the turret
            partToRotate = transform.GetChild(0);
            Quaternion lookRotation = Quaternion.LookRotation(target.transform.position - transform.position);
            partToRotate.rotation = Quaternion.Euler(0f, Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles.y, 0f);

            if (attackCountdown <= 0f)
            {
                Attack();
                attackCountdown = 1f / attackRate;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        UnityEditor.Handles.color = Color.red;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.up, range);

        if (target != null)
        {
            Gizmos.color = attackCountdown <= .1f ? Color.red : Color.cyan;
            Gizmos.DrawLine(transform.position, target.transform.position);
        }
    }
}
