using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_T_R_AI : MonoBehaviour
{
    public Transform player_position;
    public float B_T_R_speed;
    public float attack_range = 3.5f;
    public float aggro_range = 25f;

    private float last_attack_time;
    private bool is_attacking = false;
    public float attack_cd;

    private Rigidbody2D rb;
    private Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject player = GameObject.FingGameObjectWithTag("Player");
        player_position = player.transform;
    }

   
    void Update()
    {
        float distance_to_player = Vector2.Distance(transform.position, player_position.position);
        if (agro_range >= distance_to_player)
        {
            if (distance_to_player > attack_range)
            { 
            
            
            }
            else
            {
                
                
                
            }
        }
        


    }
}
