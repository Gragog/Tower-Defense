using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBullet : IAttackBehavior {

    public bool Attack(GameObject target, float damageAmount)
    {
        Debug.Log("Shooting Bullet at " + target.name + " dealing " + damageAmount + " damage!");
        return target.GetComponent<EnemyHealthController>().DealDamage(damageAmount);
    }
}
