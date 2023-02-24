using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    private float speed = 5;

    [SerializeField]
    private float jumpForce = 10;

    [SerializeField]
    private Transform groundChecker;

    [SerializeField]
    private LayerMask playerLayerMask;

    private float xMove = 0;

    public bool isGrounded = false;

    // TODO: Double jump

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    private void CheckGrounded() {
        var hit = Physics2D.Raycast(groundChecker.position, Vector2.down, 0.1f, playerLayerMask);
        if(hit.collider == null) {
            isGrounded = false;
        } else {
            isGrounded = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckGrounded();

        xMove = 0;

        if (Input.GetKey(KeyCode.D)) {
            xMove = speed;
        }
        if(Input.GetKey(KeyCode.A)) {
            xMove = -speed;
        }
        
        if(Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        rb.velocity = new Vector2(xMove, rb.velocity.y);
    }
}
