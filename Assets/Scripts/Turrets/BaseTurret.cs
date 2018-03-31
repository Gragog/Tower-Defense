using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTurret: MonoBehaviour {

    public float range = 15f;

    IAttackBehavior attackBehavior;

    public Transform target;

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

        if (target != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position, target.position);
        }
    }
}
