using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{    
    public Rigidbody2D body;

    int jumpCount = 0;
    public int maxJumps = 2;

    private bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        float speed = 10;

        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //flip body
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // space key pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }

        // applying gravitychange when jumping
        if (body.velocity.y >= 0)
        {
            body.gravityScale = 10;
        }
        else if (body.velocity.y < 0)
        {
            body.gravityScale = 30;
        }
    }
    private void jump()
    {
        int jumpPower = 30;

        if (jumpCount <= maxJumps)
        {
            body.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jumpCount++;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collison)
    {
        if (collison.gameObject.tag == "Ground")
        {
            jumpCount = 0;            
        }
    }
}
