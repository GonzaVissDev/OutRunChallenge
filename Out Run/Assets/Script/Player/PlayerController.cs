using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("Player Speed")]
    public float Speed = 5f;

    [Tooltip("Impact Force")]
    public float Force = 5f;

    [HideInInspector]
    public bool Run = false;

    [Tooltip("Scroll Map Settings")]
    public PathManager Sc;

    private Rigidbody rb;
    private Animator anim;
    //Singleton Pattern
    public static PlayerController Instance_PlayerController { get; private set; }


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        Instance_PlayerController = this;
    }

    private void FixedUpdate()
    {
        //Player Movement
        if (Run == true)
        {
            float xMovement = Input.GetAxis("Horizontal") * Speed / 2;
            transform.Translate(new Vector3(xMovement, 0, Speed) * Time.deltaTime);
            anim.SetFloat("Rotate", xMovement);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Spawn")
        {
            //Active Method in "PathManager Script"
            Sc.ScrollRoad();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        //Player Collision: Enemy
        if (collision.gameObject.tag == "Car")
        {
             rb.AddForce(transform.up * Force,ForceMode.Impulse);
            anim.enabled = false;
           
            Run = false;
            GameController.Instance_Gm.GameOver();
          
        }
    }


}
