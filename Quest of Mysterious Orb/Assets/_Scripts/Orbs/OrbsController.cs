using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbsController : ExecutableController, IUpdatable, IEnableable, IDisaable, ILateUpdatable
{
    [SerializeField]
    private List<OrbObject> orbsList;

    public List<OrbObject> OrbsList { get => orbsList; set => orbsList = value; }

    public void OnIDisable()
    {
        
    }

    public void OnIEnable()
    {
        
    }

    public void OnIUpdate()
    {
        orbsList.ForEach((x) => {
            (x as IUpdatable).OnIUpdate();
        });
    }
    
    public void OnILateUpdate() {

    }

    public void AddToOrbList(OrbGameObject orbObject) {
        orbsList.Add(orbObject);
    }
}
