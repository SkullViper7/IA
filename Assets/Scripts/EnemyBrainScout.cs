using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyBrainScout : MonoBehaviour
{
    public Transform[] waypoints;

    [Space]
    public float moveSpeed;
    public float rotateSpeed;
    
    int currentWaypoint;
    bool isOnPoint;

    private void Start()
    {
        currentWaypoint = 0;
    }

    private void FixedUpdate()
    {
        if (isOnPoint)
        {
            currentWaypoint++;
            isOnPoint = false;
        }

        if (currentWaypoint == waypoints.Length)
        {
            currentWaypoint = 0;
        }

        FollowWaypoints();
    }

    void FollowWaypoints()
    {
        Vector3 direction = waypoints[currentWaypoint].position - transform.position;

        if (direction.magnitude <= 0.3f)
        {
            isOnPoint = true;
        }

        Vector3 currentForward = transform.forward;
        float angle = MathHelper.AngleBetween(currentForward, direction);

        float rotationStep = rotateSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationStep);

        Vector3 velocity = moveSpeed * Time.deltaTime * direction.normalized;

        transform.Translate(velocity, Space.World);
    }
}
