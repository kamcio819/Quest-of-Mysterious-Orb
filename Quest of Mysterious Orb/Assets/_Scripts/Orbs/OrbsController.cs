using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbsController : ExecutableController, IUpdatable, IEnableable, IDisaable, ILateUpdatable, IAwakable
{
    private List<OrbObject> orbsList;

    public List<OrbObject> OrbsList { get => orbsList; set => orbsList = value; }

    [SerializeField]
    private List<OrbObject> orbObject;

    public void OnIAwake() {
        orbsList = new List<OrbObject>();
        for(int i = 0 ; i < orbObject.Count; ++i) {
            MyObjectPoolManager.Instance.CreatePoolIfNotExists(orbObject[i].gameObject, 20, 50);
        } 
    }

    public void OnIDisable()
    {
        for(int i = 0; i < orbsList.Count; ++i) {
            (orbsList[i] as IDisaable).OnIDisable();
        }
    }

    public void OnIEnable()
    {
        for(int i = 0; i < orbsList.Count; ++i) {
            (orbsList[i] as IEnableable).OnIEnable();
        }
    }

    public void Update()
    {
        for(int i = 0; i < orbsList.Count; ++i) {
            (orbsList[i] as IUpdatable).OnIUpdate();
        }
    }
    
    public void OnILateUpdate() {

    }

    public void AddToOrbList(OrbGameObject orbObject) {
        orbsList.Add(orbObject);
    }

    public void RemoveOrbFromList(OrbGameObject orbObject) {
        orbsList.Remove(orbObject);
    }

    private void SpawnOrb(bool isActive) {
        
    }

   public void OnIUpdate()
   {
      
   }
}
