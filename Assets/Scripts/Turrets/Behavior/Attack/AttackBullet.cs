using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBullet : MonoBehaviour, IAttackBehavior {

    public void Attack(Transform targetPosition, float damageAmount)
    {
        Debug.Log("Shooting Bullet dealing " + damageAmount + " damage!");
    }
}
