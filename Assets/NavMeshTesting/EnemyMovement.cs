using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 targetPoint;

    private float pointPrecision = 1;

    // Start is called before the first frame update
    void Start()
    {
        targetPoint = GenerateRandomPoint();
    }

    private Vector3 GenerateRandomPoint() {
        return new Vector3(Random.Range(0, 100), 0, Random.Range(0, 100));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
