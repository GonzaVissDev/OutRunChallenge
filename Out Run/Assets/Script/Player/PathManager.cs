using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathManager : MonoBehaviour
{

    public List<GameObject> Roads = new List<GameObject>();
   public float OffSet = 60f;
    // Start is called before the first frame update
    void Start()
    {
        //CODIGO PARA ORDENAR LAS CALLES 

      /*  if (Roads != null && Roads.Count > 0)
        {
            Roads = Roads.OrderBy(r => r.transform.position.z).ToList();

        }*/
    }

   public void ScrollRoad()
    {
        GameObject Scroll = Roads[0];
        Roads.Remove(Scroll);
        float newZ = Roads[Roads.Count - 1].transform.position.z + OffSet;
        Scroll.transform.position = new Vector3(0, 0, newZ);
        Roads.Add(Scroll);
    }
}
