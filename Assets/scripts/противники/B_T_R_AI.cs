using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_T_R_AI : MonoBehaviour
{
    public Transform player_position;
    public float B_T_R_speed;
    public float attack_range;
    public float aggro_range;

    private bool is_attacking = false;
    private bool is_aggr = false;
    private bool is_dash;
    public float dash_time;
    public float attack_time;
    public float knock_cd;
    private float last_dash_time;
    private float last_attack_time;
    private float last_knock_time;
    private HP HP_script;
    private Rigidbody2D rb;
    private Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player_position = player.transform;
        HP_script = player.GetComponent<HP>();
    }

   
    void Update()
    {
       if (last_knock_time + knock_cd  >= Time.time)
        {
            return;
        }

        if (is_dash == true)
        {
            if (last_dash_time + dash_time <= Time.time)
            {
                is_dash = false;
                rb.velocity = Vector2.zero;
                last_knock_time = Time.time;
                
            }
            return;
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
            else if (is_aggr == true && is_dash == false)
            {
                dash();
            }


        }
        




    }
    private void attack()
    {
        rb.velocity = Vector2.zero;
        last_attack_time = Time.time;
        Debug.Log("atck");
        HP_script.take_damage(1);
    }
    private void dash()
    {
       
        Debug.Log("dash");
        is_dash = true;
        Vector2 direction = (player_position.position - transform.position).normalized;
        rb.velocity = direction * B_T_R_speed;
        last_dash_time = Time.time;



    }
   
}
