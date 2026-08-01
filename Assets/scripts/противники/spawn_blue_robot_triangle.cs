using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_blue_robot_triangle : MonoBehaviour
{
    public GameObject prefab_B_R_T;
    public Transform spawn_point;
    
    void Start()
    {
        
    }
    public void spawn()
    {
        Instantiate(prefab_B_R_T, spawn_point.position, spawn_point.rotation);
        Destroy(gameObject);
    }
    
}
