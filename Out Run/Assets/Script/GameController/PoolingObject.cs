﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [System.Serializable]

    public class ObjectPoolItem
    {
        [Tooltip("Item To Pooling in the Scene")]
        public GameObject objectToPool;

        [Tooltip("How many Object")]
        public int amountToPool;

        public bool shouldExpand;
    }

    public class PoolingObject : MonoBehaviour
    {

        public static PoolingObject SharedInstance;

        [Tooltip("List of Pooling in the Scene")]
        public List<ObjectPoolItem> itemsToPool;


        [HideInInspector]
        public List<GameObject> pooledObjects;

        void Awake()
        {
            SharedInstance = this;
        }


        void Start()
        {
            pooledObjects = new List<GameObject>();
            foreach (ObjectPoolItem item in itemsToPool)
            {
                for (int i = 0; i < item.amountToPool; i++)
                {
                    GameObject obj = (GameObject)Instantiate(item.objectToPool);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                }
            }
        }

        /*--------------[ Pooling Object Method]--------------*/
        public GameObject GetPooledObject(string tag)
        {
            for (int i = 0; i < pooledObjects.Count; i++)
            {
                if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag)
                {
                    return pooledObjects[i];
                }
            }
            foreach (ObjectPoolItem item in itemsToPool)
            {
                if (item.objectToPool.tag == tag)
                {
                    if (item.shouldExpand)
                    {
                        GameObject obj = (GameObject)Instantiate(item.objectToPool);
                        obj.SetActive(false);
                        pooledObjects.Add(obj);
                        return obj;
                    }
                }
            }
            return null;
        }
    }
