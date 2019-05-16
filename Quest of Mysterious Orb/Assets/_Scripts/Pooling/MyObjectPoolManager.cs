using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class MyObjectPoolManager : Singleton<MyObjectPoolManager>
{

    private Dictionary<String, MyObjectPool> objectPools;

    private MyObjectPoolManager()
    {
        this.objectPools = new Dictionary<String, MyObjectPool>();
    }

    public bool CreatePoolIfNotExists(GameObject objToPool, int initialPoolSize, int maxPoolSize)
    {
        if (IsAlreadyHavingPoolOfThisObject(objToPool))
        {
            return false;
        }
        else
        {
            CreateNewPool(objToPool, initialPoolSize, maxPoolSize);
            return true;
        }
    }

    private bool IsAlreadyHavingPoolOfThisObject(GameObject poolObject)
    {
        return objectPools.ContainsKey(poolObject.name);
    }

    private void CreateNewPool(GameObject objToPool, int initialPoolSize, int maxPoolSize)
    {
        MyObjectPool nPool;
   
        nPool = new MyObjectPool();
        
        nPool.SetPool(objToPool, initialPoolSize, maxPoolSize);
        objectPools.Add(objToPool.name, nPool);
    }

    public GameObject GetObject(string objName, bool shouldActvateObject)
    {
        return MyObjectPoolManager.Instance.objectPools[objName].GetObject(shouldActvateObject);
    }

    public void DisableObejctsFromPool(int layer)
    {
        List<MyObjectPool> listAllPool = MyObjectPoolManager.Instance.objectPools.Values.ToList();
        
        foreach(MyObjectPool pool in listAllPool)
        {
            if (pool.GetIDLayer() == layer)
                pool.DisableAllObjects();
        }
    }

    public void ClearAllPoolObjects()
    {
        List<MyObjectPool> listAllPool = MyObjectPoolManager.Instance.objectPools.Values.ToList();
        {
            foreach (MyObjectPool pool in listAllPool)
            {
                pool.ClearObjects();
            }
        }

        MyObjectPoolManager.Instance.objectPools.Clear();
        
    }
}
