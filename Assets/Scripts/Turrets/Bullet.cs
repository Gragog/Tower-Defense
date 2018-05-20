using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 25f;
    public ParticleSystem impactEffect;

    GameObject target;
    TurretBullet turret;

    public void Seek(GameObject target, TurretBullet turret)
    {
        this.target = target;
        this.turret = turret;
    }

	// Update is called once per frame
	void Update () {
        if (! target)
        {
            DestroyBullet();
            return;
        }

        Vector3 dir = target.transform.position - transform.position;
        float distanceThisFrame = Time.deltaTime * speed;

        if (dir.sqrMagnitude <= (distanceThisFrame * distanceThisFrame) + .5f)
        {
            if (target.GetComponent<EnemyHealthController>().DealDamage(turret.damagePerHit))
                turret.RemoveTarget();

            DestroyBullet();
            return;
        }

        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        transform.LookAt(target.transform);
    }

    private void DestroyBullet()
    {
        if (impactEffect) Instantiate(impactEffect, transform.position, transform.rotation, transform.parent);

        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        if (target)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, target.transform.position);
        }
    }
}
