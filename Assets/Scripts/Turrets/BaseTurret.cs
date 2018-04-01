using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTurret: MonoBehaviour {

    public float range = 15f;
    public float damagePerHit = 5f;
    public float attackRate = 1f;

    float attackCountdown;

    IAttackBehavior attackBehavior;

    public GameObject target;

    protected void Init()
    {
        attackCountdown = attackRate;
        InvokeRepeating("UpdateTarget", 0f, .5f);
    }

    protected void SetAttackBehavior(IAttackBehavior behavior)
    {
        attackBehavior = behavior;
    }

    protected void Attack()
    {
        if (attackBehavior.Attack(target, damagePerHit)) target = null;
    }

    void UpdateTarget()
    {
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in EnemyFinder.enemies)
        {
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
            // Rotate the Base of the turret
            Transform partToRotate = transform.GetChild(0);
            Quaternion lookRotation = Quaternion.LookRotation(target.transform.position - transform.position);
            partToRotate.rotation = Quaternion.Euler(0f, lookRotation.eulerAngles.y, 0f);

            if (attackCountdown <= 0f)
            {
                Attack();
                attackCountdown = attackRate;
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
