using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class dialogue : MonoBehaviour
{
    public TextMeshProUGUI Text_component;
    public string[] lines;
    public float text_speed;
    private int index;
    void OnEnable()
    {
       
        Text_component.text = string.Empty;
        
        Start_Dialogue();
       
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (Text_component.text == lines[index])
            {
                Next_Line();
            }
            else
            {
                StopAllCoroutines();
                Text_component.text = lines[index];
            }
        }
    }

     void Start_Dialogue()
     {
        index = 0;
        Debug.Log(character_move.character_full_lock);
        character_move.character_full_lock = true;
        Debug.Log(character_move.character_full_lock);
        StartCoroutine(type());
     }
     IEnumerator type()
     {
        foreach(char i in lines[index].ToCharArray())
        {
            Text_component.text += i;
            yield return new WaitForSeconds(text_speed);

        }
     }
    void Next_Line()
    {
        if(index < lines.Length - 1)
        {
            index += 1;
            Text_component.text = string.Empty;
            StartCoroutine(type());
        }
        else
        {
            gameObject.SetActive(false);
            character_move.character_full_lock = false;

        }
    }
}   
