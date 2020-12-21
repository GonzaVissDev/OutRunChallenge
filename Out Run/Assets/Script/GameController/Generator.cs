using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [Tooltip("Spawn Position´s")]
    public Transform[] RandomPositions;

    [Tooltip("Tag´s Object")]
    public string[] Tag;

    public static Generator Instance_Generator { get; private set; }

    [Tooltip("Spawn Time")]
    public float SpawTime;


    void Start()
    {
        Instance_Generator = this;
    }

    private void Update()
    {
        //in this demo i move the generator based on the player
        this.transform.position = new Vector3(0, 0.5f, PlayerController.Instance_PlayerController.transform.position.z + 150f);
    }
   
    public void StartGenerator()
    {
        InvokeRepeating("InstanciateObject", 1.2f, SpawTime);
    }

    public void CancelGenerator()
    {
        CancelInvoke("StartGenerator");

    }

    /*--------------[ Spawn Object Method for "PoolingObject Script"]--------------*/
    public void InstanciateObject()
    {
        int RandomObject = Random.Range(0, Tag.Length);

        GameObject Obstacle_Object = PoolingObject.SharedInstance.GetPooledObject(Tag[RandomObject]);

        if (Obstacle_Object != null)
        {

            int RandomPos = Random.Range(0, RandomPositions.Length);
            Obstacle_Object.transform.position = RandomPositions[RandomPos].transform.position;

            //Here the objects are activated according to the position found in the object pooling.
            Obstacle_Object.SetActive(true);

        }
    }

}

