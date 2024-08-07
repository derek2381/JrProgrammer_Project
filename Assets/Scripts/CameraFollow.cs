using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // The player's transform
    public Vector3 offset;   // The offset distance between the player and camera

    void Start()
    {
        // You can set the offset based on the initial positions if not manually set
        if (player != null && offset == Vector3.zero)
        {
            offset = transform.position - player.position;
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Update the camera's position based on the player's position and offset
            transform.position = player.position + offset;
        }
    }
}