using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBullet : IAttackBehavior {

    public GameObject bulletPrefab;
    public Transform bulletOrigin;

    public AttackBullet(GameObject bulletPrefab, Transform bulletOrigin)
    {
        this.bulletPrefab = bulletPrefab;
        this.bulletOrigin = bulletOrigin;
    }

    public bool Attack(GameObject target, float damageAmount)
    {
        // Debug.Log("Shooting Bullet at " + target.name + " dealing " + damageAmount + " damage!");
        return target.GetComponent<EnemyHealthController>().DealDamage(damageAmount);
    }
}
