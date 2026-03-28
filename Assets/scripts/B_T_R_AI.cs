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
    public float attack_cd;

    private Rigidbody2D rb;
    private Animator animator;
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
}
