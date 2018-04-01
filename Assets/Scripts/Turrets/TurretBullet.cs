using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : BaseTurret {

	// Use this for initialization
	void Start () {
        Init();
        SetAttackBehavior(new AttackBullet());
    }
}
