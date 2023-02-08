using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 targetPoint;

    private float pointPrecision = 1;

    private Vector3 lastPosition;
    private Quaternion lastRotation;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        targetPoint = GenerateRandomPoint();
        agent.SetDestination(targetPoint);
    }

    private Vector3 GenerateRandomPoint() {
        return new Vector3(Random.Range(0, 100), 0, Random.Range(0, 100));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 checkPosition = transform.position;
        checkPosition.y = 0;

        if(Vector3.Distance(checkPosition, targetPoint) < pointPrecision || IsNotMoving()) {
            targetPoint = GenerateRandomPoint();
            agent.SetDestination(targetPoint);
        }


        lastPosition = transform.position;
        lastRotation = transform.rotation;
    }

    private bool IsNotMoving() {
        return Vector3.Distance(lastPosition, transform.position) < 0.000001 
            && Quaternion.Angle(lastRotation, transform.rotation) < 0.000001;
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(targetPoint, 1);
    }
}
