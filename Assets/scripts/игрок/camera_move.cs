using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_move : MonoBehaviour
{
    public Transform player_pos;
    public Vector3 ofset;
    public float dead_zone;
    public float dead_zone_ofset;

    void LateUpdate()
    {
        Vector3 camera_pos = transform.position;
        Vector3 pos = player_pos.position + ofset;
        float diffY = pos.y - camera_pos.y - dead_zone_ofset;
        //pos.x = pos.x - Mathf.Clamp(pos.x - camera_pos.x, - dead_zone.x, dead_zone.x);
        pos.y = camera_pos.y + (diffY - Mathf.Clamp(diffY, -dead_zone, dead_zone));
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * 5f);
    }
}
