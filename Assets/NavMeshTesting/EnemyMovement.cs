using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    private PlayerState playerState;

    private NavMeshAgent agent;
    private Vector3 targetPoint;

    private float pointPrecision = 1;

    private Vector3 lastPosition;
    private Quaternion lastRotation;

    [SerializeField]
    private PlayerKolize playerKolize;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerState = GetComponent<PlayerState>();

        targetPoint = GenerateRandomPoint();
        agent.SetDestination(targetPoint);
    }

    private Vector3 GenerateRandomPoint() {
        return new Vector3(Random.Range(0, 100), 0, Random.Range(0, 100));
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, playerKolize.transform.position) > 10) {
            MoveRandomly();
        } else {
            if(playerKolize.PlayerState.PlayerStateEnum == playerState.PlayerStateEnum) {
                MoveRandomly();
            } else {
                if(playerKolize.WouldEnemyWin(playerState.PlayerStateEnum)) {
                    MoveTowardsPlayer();
                } else {
                    RunFromPlayer();
                }
            }
        }

    }

    void MoveRandomly() {
        Vector3 checkPosition = transform.position;
        checkPosition.y = 0;

        if (Vector3.Distance(checkPosition, targetPoint) < pointPrecision || IsNotMoving()) {
            targetPoint = GenerateRandomPoint();
            agent.SetDestination(targetPoint);
        }

        lastPosition = transform.position;
        lastRotation = transform.rotation;
    }

    void MoveTowardsPlayer() {
        agent.SetDestination(playerKolize.transform.position);
    }

    void RunFromPlayer() {
        var dir = playerKolize.transform.position - transform.position;
        dir.y = 0;
        dir *= -1;
        agent.SetDestination(transform.position + dir);
    }


    private bool IsNotMoving() {
        return Vector3.Distance(lastPosition, transform.position) < 0.000001 
            && Quaternion.Angle(lastRotation, transform.rotation) < 0.000001;
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(targetPoint, 1);
    }
}
