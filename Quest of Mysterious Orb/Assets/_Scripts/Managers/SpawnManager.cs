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
            yield return new WaitForSeconds(10);
            chunk = currentPlayerChunk.GetComponent<Chunk>();
            foreach (Transform spawn in chunk.spawnerPoints)
            {
                if (Random.Range(0, DronsPerDwarf) >= DronsPerDwarf - 1)
                {
                    enemy = MyObjectPoolManager.Instance.GetObject("BossEnemy", true).transform;
                }
                else
                {
                    enemy = MyObjectPoolManager.Instance.GetObject("ChargingEnemy", true).transform;
                }
                enemy.transform.position = spawn.position;
                enemy.GetComponent<EnemyObject>().isSpawned = true;
                if(enemyController.EnemiesObject.Count <= 50) {
                    enemyController.EnemiesObject.Add(enemy.GetComponent<EnemyObject>());
                } 
            }

            foreach (Transform spawn in chunk.spawnerPointsTurrets)
            {
                enemy = MyObjectPoolManager.Instance.GetObject("TurretEnemy", true).transform;
                enemy.transform.position = spawn.position;
                enemy.GetComponent<EnemyObject>().isSpawned = true;
                if(enemyController.EnemiesObject.Count <= 50) {
                    enemyController.EnemiesObject.Add(enemy.GetComponent<EnemyObject>());
                } 
            }
        }
    }
}
