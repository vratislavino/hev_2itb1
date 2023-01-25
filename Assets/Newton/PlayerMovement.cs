using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Transform t;

    [SerializeField]
    float speed;

    [SerializeField]
    Vector2 borders;



    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;
        
        if(Input.GetKey(KeyCode.A))
        {
            movement.x = -speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement.x = speed;
        }

        t.position += movement * Time.deltaTime;

        if (t.position.x < borders.x)
            t.position = new Vector3(borders.x, t.position.y, t.position.z);

        if (t.position.x > borders.y)
            t.position = new Vector3(borders.y, t.position.y, t.position.z);
    }
}
