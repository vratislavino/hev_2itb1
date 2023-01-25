using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleGenerator : MonoBehaviour
{
    [SerializeField]
    private float interval = 0.5f;
    private float currentCooldown = 0;

    [SerializeField]
    GameObject applePrefab;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("GenerateApple", 0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentCooldown <= 0)
        {
            GenerateApple();
            currentCooldown = interval;
        } else
        {
            currentCooldown -= Time.deltaTime;
        }
    }

    void GenerateApple()
    {
        Destroy(Instantiate(applePrefab, GeneratePosition(), Quaternion.identity), 4f);
    }

    Vector3 GeneratePosition()
    {
        return new Vector3(Random.Range(-2.5f, 2.5f), transform.position.y, transform.position.z);
    }
}
