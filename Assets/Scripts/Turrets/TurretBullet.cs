using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : BaseTurret {

    public float damagePerHit = 5f;

	// Use this for initialization
	void Start () {
        SetAttackBehavior(new AttackBullet());
    }

    private void Update()
    {
        Attack(transform, damagePerHit);
    }
}
