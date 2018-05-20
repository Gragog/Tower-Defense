using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 25f;

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
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.transform.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        transform.LookAt(target.transform);

        if (Vector3.SqrMagnitude(dir) < .2f)
        {
            if (target.GetComponent<EnemyHealthController>().DealDamage(turret.damagePerHit))
                turret.RemoveTarget();

            Destroy(gameObject);
            return;
        }
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
