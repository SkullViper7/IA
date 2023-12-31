using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrainLine : MonoBehaviour
{
    public Transform target;
    public float moveSpeed;
    public float rotateSpeed;

    private void FixedUpdate()
    {
        MoveToTarget();
    }

    void MoveToTarget()
    {
        Vector3 direction = target.position - transform.position;

        if (direction.magnitude <= 0.3f)
        {
            return;
        }

        Vector3 currentForward = transform.forward;
        float angle = MathHelper.AngleBetween(currentForward, direction);

        float rotationStep = rotateSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationStep);

        Vector3 velocity = moveSpeed * Time.deltaTime * direction.normalized;

        transform.Translate(velocity, Space.World);
    }
}
