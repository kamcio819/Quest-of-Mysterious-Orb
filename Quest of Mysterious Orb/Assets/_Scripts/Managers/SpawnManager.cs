using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject currentPlayerChunk;
    private GameObject lastPlayerChunk;

    void Start()
    {

    }

    private IEnumerator CheckPlayerPosition()
    {
        if(currentPlayerChunk != lastPlayerChunk)
        yield return new WaitForSeconds(10);
    }
}
