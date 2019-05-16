using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Autor Skellif

public class ChunkConnector : MonoBehaviour {


    private GameObject exit;     ///< <summary> zmienna zawierająca wyjście </summary>

    private List<Transform> exits;      ///< <summary> Lista wyjść chnka / kolejka wyjść </summary>
   
    private List<GameObject> aviableExits;      /// <summary> Lista wszystkich wygenerowanych wyjść </summary>

    // private List<Transform> fullExits;         /// <summary>  </summary>

    private bool mapIsBroken;
    [HideInInspector]
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
    private Transform[] EndChunk;

    [SerializeField]
    private int minL;       ///< <summary> minimalna długość ścieżki </summary>
    [SerializeField]
    private int maxL;       ///< <summary> maksymalna długość ścieżki </summary>

    [SerializeField]
    private int absoluteMinLength;

    [SerializeField]
    private int stepsCount;     ///< <summary> ilość kroków do cofnięcia </summary>

    [SerializeField]
    private int maxBranchLength;

    private Transform nextChunk;        ///< <summary> generowany chunk </summary>
    private Transform currentChunk;     ///< <summary> Ostatnio wygenerowany chunk </summary>

    private int pathLength;     ///< <summary> Długość ścieżki </summary>

    private int currentRoomCount;       ///< <summary> Ściana </summary>

    private int nextChunkType;

    private bool mainPathFlag;      ///< <summary> Czy generuje główną ścieżkę </summary>

    private bool chunkWasGenerated;
    [HideInInspector]
    public bool MapGenerated;


    private void Start()
    {
        MapControll();
    }

    //Main path

    public void MapControll()
    {
        StartCoroutine(MapHandler());
        
    }

    private IEnumerator MapHandler()
    {
        MapStart();
        if (mapIsBroken)
        {
            DestryMap();
            yield return new WaitForSeconds(1f);
            MapStart();
        }
        yield return null;
    }

    public void MapStart()
    {
        MapGenerated = false;
        exits = new List<Transform>();
        generatedChunk = new List<Transform>();
        aviableExits = new List<GameObject>();
        mapIsBroken = false;
        generatedChunk.Clear();
        aviableExits.Clear();
        currentChunk = Instantiate(startChunk[Random.Range(0, startChunk.Length)], new Vector3(0, 0, 0), Quaternion.identity);
        generatedChunk.Add(currentChunk);
        AddAviableExits();
        currentChunk.GetComponent<Chunk>().chunkType = 0;
        mainPathFlag = true;
        pathLength = Random.Range(minL, maxL);

        for (currentRoomCount = 0; currentRoomCount < pathLength; currentRoomCount++)
        {
            if (!mapIsBroken)
            {
                NextChunk();
            }
        }
        GenerateEndChunk();
        mainPathFlag = false;
        do {
            if (!mapIsBroken)
            {
                for (int i = 0; i < aviableExits.Count; i++)
                {
                    if (!mapIsBroken)
                    {
                        exit = aviableExits[i].gameObject;
                        currentChunk = exit.transform.parent.transform;
                        PickNextChunk();
                        if (Random.Range(0f, 1f) < (float)(maxBranchLength) / 10)
                        {
                            nextChunk = deadEndChunk[Random.Range(0, deadEndChunk.Length)];
                        }
                        CreateNextChunk();
                    }
                }
            }
        } while (aviableExits.Count!=0);

        if (generatedChunk.Count < absoluteMinLength) mapIsBroken = true;
        
        MapGenerated = true;
    }
    public void DestryMap()
    {
        foreach (Transform x in generatedChunk)
        {
            Destroy(x.gameObject);
        }
    }

    private void NextChunk()
    {
        if (!mapIsBroken)
        {
            PickNextChunk();
            ChooseExit();
            CreateNextChunk();
        }
    }


    private void ChooseExit()
    {
        if (!mapIsBroken)
        {
            int childCount = currentChunk.childCount;
            for (int j = 0; j < childCount; j++)
            {
                if (currentChunk.GetChild(j).tag == "Exit" && aviableExits.Contains(currentChunk.GetChild(j).gameObject))
                {

                    exits.Add(currentChunk.GetChild(j));

                }
            }
            if ((exits.Count != 0))
                exit = exits[Random.Range(0, exits.Count)].gameObject;
            else
            {
                ChooseDifrentExit();
            }

            exits.Clear();
        }
    }

    // Main path

    private void GenerateEndChunk()
    {
        if (!mapIsBroken)
        {
            nextChunk = EndChunk[Random.Range(0, EndChunk.Length)];
            ChooseLastExit();
        }
    }

    private void PickNextChunk()
    {
        if (!mapIsBroken)
        {
            switch (currentChunk.GetComponent<Chunk>().chunkType)
            {
                case 0:
                case 1:
                    nextChunkType = Random.Range(2, 3 + 1);
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
    }

    private void AddAviableExits()
    {
        int childCount = currentChunk.childCount;
        for (int j = 0; j < childCount; j++)
        {
            if (currentChunk.GetChild(j).tag == "Exit")
            {
                aviableExits.Add(currentChunk.GetChild(j).gameObject);

            }
        }
    }

    private void RemoveAviableExits()
    {
        bool removed;
        removed = aviableExits.Remove(exit);
    }



    // Collision controll

    private void CollisionHandller()
    {
        if (!mapIsBroken)
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

                }
            }
            else
            {
                //próba wygenerowania innego typu chunka
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
                    //postawienie DeadEnda
                    CutPath();
                }
            }

        }
    }
    private void CutPath()
    {
        if (aviableExits.Contains(exit))
        {
            nextChunk = deadEndWall[Random.Range(0, deadEndWall.Length)];
            CreateDiferentChunk();
        }

    }

    private void ChooseDifrentExit()
    {
        int stepBack = Random.Range(aviableExits.Count > stepsCount ? aviableExits.Count - stepsCount : 0, aviableExits.Count);
        if (aviableExits.Count == 0)
        {

        }
        else
        currentChunk = aviableExits[stepBack].transform.parent;
    }
    private void ChooseLastExit()
    {
        int i = 1;
        exit = aviableExits[aviableExits.Count - i];
        while (!CreateDiferentChunk())
        { 
            Debug.Log(i);
            i++;
            exit = aviableExits[aviableExits.Count - i];
        }
    }



    void PickDifferentChunk()
    {
        if (!mapIsBroken)
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
                default:
                    nextChunk = roomChunk[Random.Range(0, roomChunk.Length)];
                    break;

            }
            ChooseExit();
        }
    }

    // Connector

    private void CreateNextChunk()
    {
        if (!mapIsBroken)
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
                CollisionHandller();
            }
            else
            {
                currentChunk = Instantiate(nextChunk, positionTMP, rotation);
                generatedChunk.Add(currentChunk);
                currentChunk.GetComponent<Chunk>().chunkType = nextChunkType;
                RemoveAviableExits();
                AddAviableExits();
            }
        }
}
    private bool CreateDiferentChunk()
    {
        if (!mapIsBroken)
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
                currentChunk.GetComponent<Chunk>().chunkType = nextChunkType;
                generatedChunk.Add(currentChunk);
                RemoveAviableExits();
                AddAviableExits();
                return true;
            }
        }
        else return false;
    }

}
