using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrainLine : MonoBehaviour
{
    public Transform target;
    public float speed;

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

        Vector3 velocity = speed * Time.deltaTime * direction.normalized;

        transform.Translate(velocity, Space.World);
    }
}
