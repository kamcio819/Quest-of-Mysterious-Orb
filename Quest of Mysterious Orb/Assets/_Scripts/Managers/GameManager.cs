using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private void Start()
    {
        //StartCoroutine(MapTest());
    }



    private IEnumerator MapTest()
    {
        GetComponent<ChunkConnector>().MapStart();
        yield return new WaitUntil(() => GetComponent<ChunkConnector>().MapGenerated);
        yield return new WaitForSeconds(7f);
        GetComponent<ChunkConnector>().DestryMap();
        yield return new WaitForSeconds(7f);
        GetComponent<ChunkConnector>().MapStart();
        yield return null;
    }

}
