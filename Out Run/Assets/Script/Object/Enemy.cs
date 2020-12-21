using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Tooltip("Car Speed")]
    public float EnemySpeed = 3f;

    [Tooltip("Time Active in Scene")]
    public float timeInscene = 5f;
  

    private void OnEnable()
    {
         StartCoroutine(ReSpawn());
    }


    public void FixedUpdate()
    {
        //Enemy Movement
        transform.Translate(new Vector3(0, 0,EnemySpeed ) * Time.deltaTime);
    }
   
    /*--------------[For Pooling Object Method in "PoolingObject Script"]--------------*/
    IEnumerator ReSpawn()
    {
            yield return new WaitForSeconds(timeInscene) ;

            gameObject.SetActive(false);

     }
    
}
