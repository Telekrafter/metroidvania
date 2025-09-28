using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_move : MonoBehaviour
{
    private float character_speed = 10f;
    private float speed;
    private float horizontal;
    Rigidbody2D rb;
    private bool ONground;
    private bool double_jump;
    private float gravity;
    private int in_jump = 1;
    private Animator animator;
    private bool is_attacking = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        ONground = true;
        double_jump = false;
        gravity = rb.gravityScale;
        speed = character_speed;

    }
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            transform.Translate(new Vector3(horizontal, 0, 0) * Time.deltaTime * speed);

        }
        if (Input.GetButtonDown("Jump") && (ONground || double_jump))
        {
            Debug.Log("jump");
            
            speed = character_speed / 2;
            rb.velocity = new Vector2(rb.velocity.x, 12);
            rb.gravityScale = gravity;
            if (double_jump)
            { 
                double_jump = false;
                rb.velocity = new Vector2(rb.velocity.x, 12);

            }
            if (ONground == true)
            {
                double_jump = true;
                ONground = false;
               
            }
            

        }

        if (Input.GetButtonDown("Fire1") && is_attacking == false)
            { 
                animator.SetTrigger("pipe attack");
                is_attacking = true;
                speed = 0;
            }
        
        if (rb.velocity.y < 0.1)
        {
            rb.gravityScale = gravity * 1.5f;
        }
        if (rb.velocity.y == 0 && is_attacking == false) 
        {
            rb.gravityScale = gravity; 
            speed = character_speed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("ground"))
        {
            ONground = true;

        }
    }
    public void Attacke()
    {
        is_attacking = false;
        speed = character_speed;

    }
}
