using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : BaseTurret {

    public GameObject bulletPrefab;
    Transform bulletOrigin;

    // Use this for initialization
    protected new void Start () {
        base.Start();

        if (! bulletPrefab) Debug.LogError("No bullet prefab given!");
        bulletOrigin = transform.GetChild(0).GetChild(0);
    }

    protected override void Attack()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletOrigin.position, bulletOrigin.rotation, transform);
        bullet.GetComponent<Bullet>().Seek(target, this);
    }

    public void RemoveTarget()
    {
        target = null;
    }
}
