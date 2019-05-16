using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : ExecutableController, IUpdatable, IEnableable, IDisaable, ILateUpdatable, IAwakable
{
    [SerializeField]
    private List<EnemyObject> enemiesObject;

    public List<EnemyObject> EnemiesObject { get => enemiesObject; set => enemiesObject = value; }

    [SerializeField]
    private List<EnemyObject> enemiesToSpawn;

    public void OnIAwake()
    { 
        for(int i = 0 ; i < enemiesToSpawn.Count; ++i) {
            MyObjectPoolManager.Instance.CreatePoolIfNotExists(enemiesToSpawn[i].gameObject, 20, 50);
        } 
    }

    public void OnIDisable()
    {
        for(int i = 0; i < enemiesObject.Count; ++i) {
            (enemiesObject[i] as IDisaable).OnIDisable();
        }
    }

    public void OnIEnable()
    {
        for(int i = 0; i < enemiesObject.Count; ++i) {
            (enemiesObject[i] as IEnableable).OnIEnable();
        }
    }

    public void OnILateUpdate()
    {
        for(int i = 0; i < enemiesObject.Count; ++i) {
            (enemiesObject[i] as ILateUpdatable).OnILateUpdate();
        }
    }

    public void OnIUpdate()
    {
        for(int i = 0; i < enemiesObject.Count; ++i) {
            (enemiesObject[i] as IUpdatable).OnIUpdate();
        }
    }
}
