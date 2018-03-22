using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTurret: MonoBehaviour {

    public IAttackBehavior attackBehavior;

    protected void SetAttackBehavior(IAttackBehavior behavior)
    {
        attackBehavior = behavior;
    }

    protected void Attack(Transform target, float damageAmount)
    {
        attackBehavior.Attack(target, damageAmount);
    }
}
