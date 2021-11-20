using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{    
    public Rigidbody2D body;

    int jumpCount = 0;
    public int maxJumps = 2;
    public AudioSource audioJump;
    public float speed;

    Animator anim;

    private bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        anim.SetBool("lari", true);
        body.velocity = new Vector2(speed, body.velocity.y);

        // space key pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            anim.SetBool("lompat", true);
            jump();
            audioJump.Play();
        }
       

        // applying gravitychange when jumping
        if (body.velocity.y >= 0)
        {
            body.gravityScale = 10;
        }
        else if (body.velocity.y < 0)
        {
            
            body.gravityScale = 20;
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
            anim.SetBool("lompat", false);
        }
    }
}
