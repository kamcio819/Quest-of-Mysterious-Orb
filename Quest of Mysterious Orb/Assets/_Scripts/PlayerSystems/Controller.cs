using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller<T> : MonoBehaviour
    where T : Data
{
    [SerializeField]
    protected T controllerData;
}
