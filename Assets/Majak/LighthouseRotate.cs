using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighthouseRotate : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.MoveRotation();    
        transform.Rotate((Vector3.up) * speed * Time.deltaTime);
        transform.Rotate(new Vector3(0, speed, 0));
    }
}
