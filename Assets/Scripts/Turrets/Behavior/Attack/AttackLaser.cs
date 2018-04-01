using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLaser : MonoBehaviour, IAttackBehavior
{
    public bool Attack(GameObject target, float damageAmount)
    {
        Debug.Log("Disintegrating " + target.name + ", dealing " + damageAmount + " damage!");

        return false;
    }
}
