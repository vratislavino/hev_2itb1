using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private float speed;
    
    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float sensitivity = 1;

    [SerializeField]
    private Transform groundedTester;

    [SerializeField]
    private Transform cameraHolder;

    private bool isGrounded = false;

    private Vector2 rot;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void MouseRotate()
    {
        rot.x += Input.GetAxis("Mouse X") * sensitivity;
        rot.y += Input.GetAxis("Mouse Y") * sensitivity;

        if (rot.y > 70)
            rot.y = 70;

        if (rot.y < -70)
            rot.y = -70;
        
        cameraHolder.localRotation = Quaternion.Euler(-rot.y, 0, 0);
        transform.rotation = Quaternion.Euler(0, rot.x, 0);
    }

    void MakeMove()
    {
        var forward = Input.GetAxisRaw("Vertical"); // -1, 0, 1
        var sides = Input.GetAxisRaw("Horizontal"); // -1, 0, 1

        //rb.velocity = new Vector3(sides, 0, forward);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(transform.up * jumpForce);
        }
        Vector3 localVelocity = (new Vector3(sides, 0, forward)).normalized * speed * Time.deltaTime;
        var transformed = transform.TransformDirection(localVelocity);

        rb.velocity = new Vector3(transformed.x, rb.velocity.y, transformed.z);
    }

    void Update()
    {
        CheckIsGrounded();
        MakeMove();
        MouseRotate();

        if (rb.velocity.y < 0)
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * 1.01f, rb.velocity.z);
    }

    void CheckIsGrounded()
    {
        // pouze pro zobrazení paprsku, nemá vliv na hru
        Debug.DrawRay(groundedTester.position, Vector3.down * 0.1f, Color.red);
        
        if (Physics.Raycast(groundedTester.position, Vector3.down, out RaycastHit hit, 0.1f))
        {
            isGrounded = true;
            //Debug.Log(hit.collider.name);
        } else
        {
            isGrounded = false;
        }
    }
}
