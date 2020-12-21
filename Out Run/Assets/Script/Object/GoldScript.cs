using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldScript : MonoBehaviour
{

    private void OnEnable()
    {
       transform.position = new Vector3(transform.position.x, transform.position.y +1f , transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        { 
            //Player Gold Count
            GameController.Instance_Gm.Gold++;
            //For Pooling object Script 
            gameObject.SetActive(false);
        }
    }
}
