using System.Collections;
using System.Collections.Generic;
using UnityEditor.TerrainTools;
using UnityEngine;

public class EnemyBrainAStar : MonoBehaviour
{
    [Header("Targets")]
    public Transform[] waypoints;
    public Transform target;

    [Header("Movement")]
    public float moveSpeed;
    public float rotateSpeed;

    float h;
    float g;
    float f;

    bool isOnPoint;

    private void FixedUpdate()
    {
        int randomPoint = Random.Range(0, waypoints.Length);

        if (isOnPoint)
        {
            g++;
            FindFastestRoute(waypoints[randomPoint], target);
            isOnPoint = false;
        }
        MoveToPlayer();
    }

    void MoveToPlayer()
    {
        Vector3 direction = target.position - transform.position;

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

    void FindFastestRoute(Transform a, Transform target)
    {
        h = MathHelper.VectorDistance(target.position, a.position);
        f = h + g;
    }
}
