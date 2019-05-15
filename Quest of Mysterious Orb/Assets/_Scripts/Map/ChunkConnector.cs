using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Autor Skellif

public class ChunkConnector : MonoBehaviour {


    private static GameObject exit;     ///< <summary> zmienna zawierająca wyjście </summary>

    private List<Transform> exits;      ///< <summary> Lista wyjść chnka / kolejka wyjść </summary>

    private List<Transform> aviableExits;      /// <summary> Lista wszystkich wygenerowanych wyjść </summary>

   // private List<Transform> fullExits;         /// <summary>  </summary>

    public List<Transform> generatedChunk;     ///< <summary> Lista wygenerowanych chunków głównej ścieżki </summary>

    [SerializeField]
    private LayerMask layerMask;        ///< <summary> Maska wasrtwy wykrywania kolizji ścian </summary>

    [SerializeField]
    private Transform[] startChunk;     ///< <summary> Chunki startowe </summary>
    [SerializeField]
    private Transform[] roomChunk;      ///< <summary> Chunki pokoi </summary>
    [SerializeField]
    private Transform[] corridorChunk;      ///< <summary> Chunki korytarzy </summary>
    [SerializeField]
    private Transform[] junctionChunk;      ///< <summary> Chunki skrzyrzowań </summary>
    [SerializeField]
    private Transform[] deadEndChunk;       ///< <summary> Chunki ślepych korytarzy </summary>
    [SerializeField]
    private Transform[] deadEndWall;      ///< <summary> Ściana </summary>

    [SerializeField]
    private int minL;       ///< <summary> minimalna długość ścieżki </summary>
    [SerializeField]
    private int maxL;       ///< <summary> maksymalna długość ścieżki </summary>

    [SerializeField]
    private int stepsCount;     ///< <summary> ilość kroków do cofnięcia </summary>

    private Transform nextChunk;        ///< <summary> generowany chunk </summary>
    private Transform currentChunk;     ///< <summary> Ostatnio wygenerowany chunk </summary>

    private int pathLength;     ///< <summary> Długość ścieżki </summary>

    private int currentRoomCount;       ///< <summary> Ściana </summary>

    private bool mainPathFlag;      ///< <summary> Czy generuje główną ścieżkę </summary>

    private bool chunkWasGenerated;

    private int prevChunkType;  ///< <summary> Poprzedni typ chunka </summary>

    private void Start()
    {
       // Random.InitState(190219981);
        exits = new List<Transform>();
        generatedChunk = new List<Transform>();
        aviableExits = new List<Transform>();
        MapStart();
    }

    //Main path

    public void MapStart()
    {
        currentChunk = Instantiate(startChunk[Random.Range(0, startChunk.Length)], new Vector3(0, 0, 0), Quaternion.identity);
        AddAviableExits();
        currentChunk.GetComponent<Chunk>().chunkType = 0;
        mainPathFlag = true;
        pathLength = Random.Range(minL, maxL);

        for (currentRoomCount = 0; currentRoomCount < pathLength; currentRoomCount++)
        {
            NextChunk();
        }
        mainPathFlag = false;

    }

    private void NextChunk()
    {
        PickNextChunk();
        ChooseExit();
        CreateNextChunk();
        AddAviableExits();
    }


    private void ChooseExit()
    {
        int childCount = currentChunk.childCount;
        for (int j = 0; j < childCount; j++)
        {
            if (currentChunk.GetChild(j).tag == "Exit")
            {
        
                exits.Add(currentChunk.GetChild(j));

            }
        }
        Debug.Log(currentChunk);
        exit = exits[Random.Range(0, exits.Count)].gameObject;
        exits.Clear();
    }

    // Filling exits




    // Main path
    private void PickNextChunk()
    {
        int nextChunkType;
        switch (currentChunk.GetComponent<Chunk>().chunkType)
        {
            case 0:
            case 1:
                nextChunkType = Random.Range(2, 3+1);
                break;
            case 2:
                nextChunkType = Random.Range(1, 3 + 1);
                break;
            case 3:
                nextChunkType = Random.Range(1, 2 + 1);
                break;
            default:
                nextChunkType = 2;
                break;

        }

        switch (nextChunkType)
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

    private void AddAviableExits()
    {
        int childCount = currentChunk.childCount;
        for (int j = 0; j < childCount; j++)
        {
            if (currentChunk.GetChild(j).tag == "Exit")
            {
                aviableExits.Add(currentChunk.GetChild(j));

            }
        }
    }

    private void RemoveAviableExits()
    {
        aviableExits.Remove(exit.transform);
    }

    // Collision controll

    private void CollisionHandller()
    {

        if (mainPathFlag)
        {
            //próba wybrania innego wyjścia w currentChunk
            PickDifferentChunk();
            ChooseExit();
            bool flag = true;
            for (int i = 0; i < 10; i++)
            {
                if (!CreateDiferentChunk())
                {
                    PickDifferentChunk();
                    ChooseExit();
                }
                else
                {
                    flag = false;
                    break;
                }
            }

            if (flag)
            {
                //Wybranie innego chunka na ścieżkę
                CutPath();
                ChooseDifrentExit();
                

                /* SCRAPPED
                //cofnięcie ścieżki o 3 kroki

                if (currentRoomCount > stepsCount)
                {
                    PathReverse(stepsCount);
                    currentRoomCount -= stepsCount;
                    Debug.Log("!");

                }*/

            }
        }
        else
        {
            //próba wygenerowania innego typu chunka
            PickDifferentChunk();
            CreateDiferentChunk();
            //postawienie DeadEnda
            CutPath();
        }
        
    }

    private void CutPath()
    {
        nextChunk = deadEndWall[Random.Range(0, deadEndWall.Length)];
        CreateDiferentChunk();
    }

    private void ChooseDifrentExit()
    {
        int stepBack = Random.Range(generatedChunk.Count > stepsCount ? generatedChunk.Count - stepsCount : 0, generatedChunk.Count);
        currentChunk = generatedChunk[stepBack];
        currentRoomCount -= generatedChunk.Count - stepBack;
    }

    

    void PickDifferentChunk()
    {
        switch (currentChunk.GetComponent<Chunk>().chunkType) 
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

    // Connector

    private void CreateNextChunk()
    {
        Transform entrance = nextChunk;

        Vector3 displacement = new Vector3(
            entrance.localPosition.x,
            0,
            entrance.localPosition.z);

        Quaternion rotation = new Quaternion();
        rotation.eulerAngles = exit.transform.rotation.eulerAngles;
        

       
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


        if (nextChunk.GetComponent<Chunk>().CheckOverlaps(layerMask, positionTMP, rotation))
        {
            CollisionHandller();
        }
        else
        {
            currentChunk = Instantiate(nextChunk, positionTMP, rotation);
            generatedChunk.Add(currentChunk);
            RemoveAviableExits();
        }
}
    private bool CreateDiferentChunk()
    {
        Transform entrance = nextChunk;

        Vector3 displacement = new Vector3(
            entrance.localPosition.x,
            0,
            entrance.localPosition.z);

        Quaternion rotation = new Quaternion();
        rotation.eulerAngles = exit.transform.rotation.eulerAngles;



        if (rotation.eulerAngles.y >= 179)
        {
            displacement.z *= -1;

        }
        if (rotation.eulerAngles.y <= 181 && rotation.eulerAngles.y >= 89)
        {
            displacement.x *= -1;
        }
        if ((rotation.eulerAngles.y >= 89 && rotation.eulerAngles.y <= 91) || (rotation.eulerAngles.y >= 269 && rotation.eulerAngles.y <= 271))
        {
            float tmp = displacement.z;
            displacement.z = displacement.x;
            displacement.x = tmp;

        }
        Vector3 positionTMP = new Vector3(exit.transform.position.x - displacement.x, 0, exit.transform.position.z - displacement.z);


        if (nextChunk.GetComponent<Chunk>().CheckOverlaps(layerMask, positionTMP, rotation))
        {
            return false;
        }
        else
        {
            currentChunk = Instantiate(nextChunk, positionTMP, rotation);
            RemoveAviableExits();
            generatedChunk.Add(currentChunk);
            return true;
        }
    }

}
