using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [HideInInspector]
    public GameObject currentPlayerChunk;


    [SerializeField]
    private int DronsPerDwarf;

    private Chunk chunk;


    public void StartEnemySpawn()
    {
        StartCoroutine(Ressurect());
    }


    private IEnumerator Ressurect()
    {
        yield return new WaitForSeconds(10);
        chunk = currentPlayerChunk.GetComponent<Chunk>();

        foreach (Transform spawn in chunk.spawnerPoints)
        {
            if (Random.Range(0, DronsPerDwarf) > DronsPerDwarf - 1)
            {
                MyObjectPoolManager.Instance.GetObject("ChargeEnemy", true).transform.position = spawn.position;
            }
            else
            {
                MyObjectPoolManager.Instance.GetObject("PatrolEnemy", true).transform.position = spawn.position;
            }
        }
        foreach (Transform spawn in chunk.spawnerPointsTurrets)
        {
            MyObjectPoolManager.Instance.GetObject("TurretEnemy", true).transform.position = spawn.position;
        }
        
    }
}
