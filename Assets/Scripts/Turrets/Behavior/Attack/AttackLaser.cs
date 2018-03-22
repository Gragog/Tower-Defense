using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLaser : MonoBehaviour, IAttackBehavior
{
    public void Attack(Transform targetPosition, float damageAmount)
    {
        Debug.Log("Disintegrating with a lazor!");
    }
}
