using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : BaseTurret {

    public GameObject bulletPrefab;

    // Use this for initialization
    void Start () {
        Init();
        SetAttackBehavior(new AttackBullet(bulletPrefab, transform.GetChild(0).GetChild(0)));
    }
}
