using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_T_R_AI : MonoBehaviour
{
    public Transform player_position;
    public float B_T_R_speed;
    public float attack_range;
    public float aggro_range;

    private float last_attack_time;
    private bool is_attacking = false;
    public float knock_cd;
    private bool is_aggr = false;
    private bool is_dash;
    private float dash_time;

    private Rigidbody2D rb;
    private Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player_position = player.transform;
    }

   
    void Update()
    {
        if (is_dash == true)
        {
            

        }
        float distance_to_player = Vector2.Distance(transform.position, player_position.position);
        if (aggro_range >= distance_to_player)
        {
            is_aggr = true;
        } 

        if (last_attack_time + knock_cd <= Time.time)
        {
            if (attack_range >= distance_to_player)
            {
                attack();
            }
            else if (is_aggr == true)
            {
                move();
            }


        }
        
        


    }
    private void attack()
    {
        rb.velocity = Vector2.zero;
        last_attack_time = Time.time;
        Debug.Log("atck");
    }
    private void move()
    {
        is_dash = true;
        Vector2 direction = (player_position.position - transform.position).normalized;
        rb.velocity = direction * B_T_R_speed;
        attack();


    }
   
}
