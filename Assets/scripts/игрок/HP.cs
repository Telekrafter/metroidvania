using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour
{
    private int hp_now;
    private int hp_max = 5;

    void Start()
    {
        hp_now = hp_max;
    }

    public void take_damage(int damage_to_player)
    {
        hp_now = hp_now - damage_to_player;
        Debug.Log(hp_now);
        if (hp_now <= 0)
        {
            dead();
        }


    }
    private void dead()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
