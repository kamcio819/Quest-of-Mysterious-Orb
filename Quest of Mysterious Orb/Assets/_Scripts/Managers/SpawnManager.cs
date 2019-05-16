using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject currentPlayerChunk;


    void Start()
    {

    }

    private IEnumerator Ressurect()
    {
        yield return new WaitForSeconds(10);
    }
}
