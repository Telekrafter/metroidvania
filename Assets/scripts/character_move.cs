using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_move : MonoBehaviour
{
    public float character_speed = 20f;
    private float horizontal;
    Rigidbody2D rb;
    private bool ONground;
    private bool double_jump;
    private float gravity;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ONground = true;
        double_jump = false;
        gravity = rb.gravityScale;

    }
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            transform.Translate(new Vector3(horizontal, 0, 0) * Time.deltaTime * character_speed);

        }
        if (Input.GetButtonDown("Jump") && (ONground || double_jump))
        {
            Debug.Log("jump");
            

            rb.velocity = new Vector2(rb.velocity.x, 8);
            rb.gravityScale = gravity;
            if (double_jump)
            { 
                double_jump = false;
                rb.velocity = new Vector2(rb.velocity.x, 6);

            }
            if (ONground == true)
            {
                double_jump = true;
                ONground = false;
                
            }

        }
        if (rb.velocity.y < 0.1)
        {
            rb.gravityScale = gravity * 1.5f;
        }
        if (rb.velocity.y == 0)
        {
            rb.gravityScale = gravity;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("ground"))
        {
            ONground = true;

        }
    }
}
