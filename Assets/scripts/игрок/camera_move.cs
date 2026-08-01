using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_move : MonoBehaviour
{
    public Transform player_pos;
    public Vector3 ofset;

    void LateUpdate()
    {
        Vector3 pos = player_pos.position;
        pos.z = -12f;
        transform.position = Vector3.Lerp(transform.position, pos + ofset, Time.deltaTime * 2f);
    }
}
