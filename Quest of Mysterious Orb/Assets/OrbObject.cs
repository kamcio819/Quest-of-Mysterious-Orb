using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbObject : MonoBehaviour
{
    [SerializeField]
    private OrbData orbData;

    public OrbData OrbData { get => orbData; }
}
