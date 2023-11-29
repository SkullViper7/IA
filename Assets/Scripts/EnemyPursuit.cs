using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPursuit : MonoBehaviour
{
    public Transform[] waypoints;

    [Space]
    public float moveSpeed;
    public float rotateSpeed;

    int currentWaypoint;
    bool isOnPoint;

    [Space]
    public Transform player;
    public Transform fixedEnemy;
    public float chaseDistance = 5f;
    NavMeshAgent agent;

    public PlayerController playerController;

    private void Start()
    {
        currentWaypoint = 0;
        agent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        float distanceToFixedEnemy = Vector3.Distance(transform.position, fixedEnemy.position);

        if (playerController.isFired)
        {
            MoveToPlayer();
        }

        else if (distanceToPlayer <= chaseDistance)
        {
            ChasePlayer();
        }

        else if (distanceToFixedEnemy <= chaseDistance)
        {
            StopMoving();
        }

        else
        {
            ResumeMoving();
        }

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

    void StopMoving()
    {
        agent.isStopped = true;
    }

    void ResumeMoving()
    {
        agent.isStopped = false;
        FollowWaypoints();
    }

    void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    void MoveToPlayer()
    {
        agent.isStopped = false;
        agent.SetDestination(player.position);

        StartCoroutine(ReturnToPatrol());
    }

    IEnumerator ReturnToPatrol()
    {
        yield return new WaitForSeconds(3);
        playerController.isFired = false;
        ResumeMoving();
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
