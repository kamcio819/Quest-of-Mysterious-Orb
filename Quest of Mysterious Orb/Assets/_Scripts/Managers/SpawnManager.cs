using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    [HideInInspector]
    public GameObject currentPlayerChunk;

    [SerializeField]
    private EnemyController enemyController;

    [SerializeField]
    private GameObject player;


    [SerializeField]
    private int DronsPerDwarf;

   
    private Chunk chunk;
    private Chunk prevChunk;

    private Transform enemy;

    private bool turretsOnce = false;
    private int waveCounter = 0;
    
    public void StartEnemySpawn()
    {
        StartCoroutine(Ressurect());
    }

    public void SpawnPlayer()
    {
        player.transform.position = new Vector3(0, 1, 0.84f);
        player.GetComponent<PlayerObject>().HealthPlayer = 100f;
        player.GetComponent<PlayerInventoryController>().ResetOrbs();
    }


    private IEnumerator Ressurect()
    {
        yield return new WaitUntil(() => currentPlayerChunk != null);
        prevChunk = currentPlayerChunk.GetComponent<Chunk>();
        while (true)
        {
            yield return new WaitForSeconds(2f);
            chunk = currentPlayerChunk.GetComponent<Chunk>();

            if(chunk != prevChunk) {
                prevChunk = chunk;
                turretsOnce = false;
                waveCounter = 0;
                enemyController.DeactivateUnUsed();
            }

            if(chunk != null) {
                if(chunk.gameObject.name == "Arena(Clone)") {
                    Transform spawnPoint = chunk.spawnerPoints[UnityEngine.Random.Range(0, chunk.spawnerPoints.Length - 1)];
                    enemy = MyObjectPoolManager.Instance.GetObject("BossEnemy", true).transform;
                    enemyController.EnemiesObject.Add(enemy.GetComponent<EnemyObject>());
                    enemy.GetComponent<EnemyObject>().isSpawned = true;
                    enemy.transform.position = spawnPoint.position;
                    break;
                }
                else {

                    if(waveCounter < 3) {
                        foreach (Transform spawn in chunk.spawnerPoints)
                        {
                            if (UnityEngine.Random.Range(0, DronsPerDwarf) >= DronsPerDwarf - 1)
                            {
                                enemy = MyObjectPoolManager.Instance.GetObject("ChargingEnemy", true).transform;
                                enemyController.EnemiesObject.Add(enemy.GetComponent<EnemyObject>());
                                enemy.GetComponent<EnemyObject>().isSpawned = true; 
                                enemy.GetComponent<EnemyObject>().Health = 75f;
                            }
                            else
                            {
                                enemy = MyObjectPoolManager.Instance.GetObject("PatrolEnemy", true).transform;
                                enemyController.EnemiesObject.Add(enemy.GetComponentInChildren<EnemyObject>());
                                enemy.GetComponentInChildren<EnemyObject>().isSpawned = true; 
                            }
                            enemy.transform.position = spawn.position;
                        }
                        waveCounter++;
                    }

                    if(!turretsOnce) {
                        foreach (Transform spawn in chunk.spawnerPointsTurrets)
                        {
                            enemy = MyObjectPoolManager.Instance.GetObject("TurretEnemy", true).transform;
                            enemy.transform.position = spawn.position;
                            enemy.GetComponent<EnemyObject>().isSpawned = true;
                            enemyController.EnemiesObject.Add(enemy.GetComponent<EnemyObject>());
                            enemy.GetComponent<EnemyObject>().Health = 40f;
                        }
                        turretsOnce = true;
                    }
                    

                }
            }
           
        }
    }
}
