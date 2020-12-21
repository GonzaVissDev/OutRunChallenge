using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Transform Player;

    [Tooltip("Camera: Y Position")]
    public float yOffset = 2f;

    [Tooltip("Camera :Z Position")]
    public float zOffset = -5f;


    void Start()
    {
        Player = GameObject.Find("Player").transform;
    }

   
    void Update()
    {
        transform.position = new Vector3(Player.position.x, Player.position.y + yOffset, Player.position.z + zOffset);
    }
}
