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

    private Transform enemy;
    public void StartEnemySpawn()
    {
        StartCoroutine(Ressurect());
    }


    private IEnumerator Ressurect()
    {
        while (true)
        {
            yield return new WaitForSeconds(20);
            chunk = currentPlayerChunk.GetComponent<Chunk>();

            foreach (Transform spawn in chunk.spawnerPoints)
            {
                if (Random.Range(0, DronsPerDwarf) >= DronsPerDwarf - 1)
                {
                    enemy = MyObjectPoolManager.Instance.GetObject("Charger", true).transform;
                }
                else
                {
                    enemy = MyObjectPoolManager.Instance.GetObject("PatrolEnemy", true).transform;
                }
                enemy.transform.position = spawn.position;
                enemy.GetComponent<EnemyObject>().isSpawned = true;
            }
            foreach (Transform spawn in chunk.spawnerPointsTurrets)
            {
                enemy = MyObjectPoolManager.Instance.GetObject("PatrolEnemy", true).transform;
                enemy.transform.position = spawn.position;
                enemy.GetComponent<EnemyObject>().isSpawned = true;
        }
        }
    }
}
