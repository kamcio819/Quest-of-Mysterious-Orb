using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Autor Skellif

public class ChunkConnector : MonoBehaviour {


    private static GameObject exit;

    private List<Transform> exits;

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private Transform[] startChunk;
    [SerializeField]
    private Transform[] roomChunk;
    [SerializeField]
    private Transform[] corridorChunk;
    [SerializeField]
    private Transform[] junctionChunk;
    [SerializeField]
    private Transform[] deadEndChunk;
    [SerializeField]
    private Transform deadEndWall;

    [SerializeField]
    private int minL;
    [SerializeField]
    private int maxL;

    private Transform nextChunk;
    private Transform currentChunk;

    private int pathLength;

    private int prevChunkType;

    private void Start()
    {
       // Random.InitState(190219981);
        exits = new List<Transform>();
        MapStart();
    }

    //Main path

    public void MapStart()
    {
        currentChunk = Instantiate(startChunk[Random.Range(0, startChunk.Length)], new Vector3(0, 0, 0), Quaternion.identity);
        prevChunkType = 0;
        pathLength = Random.Range(minL, maxL);

        for (int i = 0; i < pathLength; i++)
        {
            NextChunk();
        }

    }

    private void NextChunk()
    {
        PickNextChunk();
        int childCount = currentChunk.childCount;
        for (int j = 0; j < childCount; j++)
        {
            if(currentChunk.GetChild(j).tag == "Exit")
            {
                exits.Add(currentChunk.GetChild(j));

            }
        }
        ChooseExit();
        CreateNextChunk();
    }


    private void ChooseExit()
    {
        exit = exits[Random.Range(0, exits.Count)].gameObject;
        exits.Clear();
    }

    // Filling exits


    // Next chunk


    // Main path
    private void PickNextChunk()
    {
        switch (prevChunkType)
        {
            case 0:
            case 1:
                prevChunkType = Random.Range(2, 3+1);
                break;
            case 2:
                prevChunkType = Random.Range(1, 3 + 1);
                break;
            case 3:
                prevChunkType = Random.Range(1, 2 + 1);
                break;

        }

        switch (prevChunkType)
        {
            case 1:
                nextChunk = roomChunk[Random.Range(0, roomChunk.Length)];
                break;
            case 2:
                nextChunk = corridorChunk[Random.Range(0, corridorChunk.Length)];
                break;
            case 3:
                nextChunk = junctionChunk[Random.Range(0, junctionChunk.Length)];
                break;

        }
    }

    // Collision controll

    // Connector

    private void CreateNextChunk()
    {
        Transform entrance = nextChunk;//.GetChild(0);

        Vector3 displacement = new Vector3(
            entrance.localPosition.x,
            0,
            entrance.localPosition.z);

        Quaternion rotation = new Quaternion();
        rotation.eulerAngles = exit.transform.rotation.eulerAngles;// - currentChunk.rotation.eulerAngles;
        

       
        if (rotation.eulerAngles.y >= 179)
        {
            displacement.z *= -1;

        }
        if (rotation.eulerAngles.y <= 181 && rotation.eulerAngles.y >= 89)
        {
            displacement.x *= -1;
        }
        if ((rotation.eulerAngles.y >= 89 && rotation.eulerAngles.y <= 91)|| (rotation.eulerAngles.y >= 269 && rotation.eulerAngles.y <= 271))
        {
            float tmp = displacement.z;
            displacement.z = displacement.x;
            displacement.x = tmp;

        }
        Vector3 positionTMP = new Vector3(exit.transform.position.x - displacement.x, 0, exit.transform.position.z - displacement.z);
        if(nextChunk.GetComponent<Chunk>().CheckOverlaps(layerMask, positionTMP, rotation))
        {
            Debug.Log("Collision");
        }

        currentChunk = Instantiate(nextChunk, positionTMP, rotation);
    }

}
