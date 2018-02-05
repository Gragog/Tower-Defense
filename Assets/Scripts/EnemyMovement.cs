using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed = 20f;
    [Range(0f, 5f)]
    public float offsetRange = .4f;

    Transform baseTarget;
    int waypointIndex = 0;
    Vector3 walkTo;
    bool hasTarget = false;

    // Use this for initialization
    void Start()
    {
        baseTarget = Waypoints.waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasTarget && baseTarget != null)
        {
            GetWalkTo();
        }

        Vector3 dir = walkTo - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.SqrMagnitude(walkTo - transform.position) < .3f)
        {
            waypointIndex++;
            hasTarget = false;
            if (waypointIndex >= Waypoints.waypoints.Length)
            {
                // deal damage
                DestroyObject(transform.gameObject);
                return;
            }
            baseTarget = Waypoints.waypoints[waypointIndex];
        }
    }

    void GetWalkTo()
    {
        walkTo = baseTarget.position;
        walkTo.x += Random.Range(-offsetRange, offsetRange + 1);
        walkTo.z += Random.Range(-offsetRange, offsetRange + 1);
        hasTarget = true;
    }
}
