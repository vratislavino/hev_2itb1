using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField]
    GameObject ballPrefab;

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateBall();
        }
    }

    private void CreateBall()
    {
        Destroy(Instantiate(ballPrefab, transform.position, Quaternion.identity), 10f);
    }
}
