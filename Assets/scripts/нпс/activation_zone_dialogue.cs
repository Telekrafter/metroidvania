using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activation_zone_dialogue : MonoBehaviour
{
    public GameObject dialogue_box;
   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogue_box.SetActive(true);
           
            
        }

    }
    


}
