using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ExecutableController : Controller
{

}

public abstract class ExecutableController<T> : Controller
    where T : Data
{
    [SerializeField]
    protected T controllerData;
}

public abstract class ExecutableController<TOne, TTwo> : Controller
    where TOne : Data
    where TTwo : Data
{
    [SerializeField]
    protected TOne firstData;

    [SerializeField]
    protected TTwo secondData;

    public Data GetData<T>() 
        where T : Data  
    {
        if(typeof(T) == typeof(TOne)) {
            return firstData;
        }
        if(typeof(T) == typeof(TTwo)) {
            return secondData;
        }
        else {
            return null;
        }
    }
}

