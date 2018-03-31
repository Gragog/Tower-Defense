using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTurret: MonoBehaviour {

    public float range = 10f;

    IAttackBehavior attackBehavior;

    Transform target;

    protected void SetAttackBehavior(IAttackBehavior behavior)
    {
        attackBehavior = behavior;
    }

    protected void Attack(Transform target, float damageAmount)
    {
        attackBehavior.Attack(target, damageAmount);
    }

    private void OnDrawGizmosSelected()
    {
        UnityEditor.Handles.color = Color.red;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.up, range);
    }
}
