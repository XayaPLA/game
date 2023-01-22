using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    private Transform Target;
    private int Waypointindex;
    // Start is called before the first frame update
    void Start()
    {
        Target = Waypoints.waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Target.position - transform.position;
        transform.Translate(dir.normalized * speed *Time.deltaTime, Space.World);

        if (Vector3.Distance(Target.position, transform.position) <= 0.5) GetNextWaypoint();
    }

    void GetNextWaypoint()
    {
        if (Waypointindex >= Waypoints.waypoints.Length - 1) { 
            Destroy(gameObject);
            return;
        }

        Waypointindex++;
        Target = Waypoints.waypoints[Waypointindex];
    }
}
