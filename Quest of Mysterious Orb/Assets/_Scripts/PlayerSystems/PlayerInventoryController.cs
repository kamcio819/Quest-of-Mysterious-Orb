using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryController : ExecutableController<InventoryData>, IEnableable, IUpdatable, IDisaable, ILateUpdatable
{
    [SerializeField]
    private List<OrbObject> inventoryOrbs;

    [SerializeField]
    private UIController uiController;

    public List<OrbObject> InventoryOrbs { get => inventoryOrbs; set => inventoryOrbs = value; }

    public void OnIDisable()
    {
        PlayerCollisionController.OrbCollected -= ProcessOrbCollection;
    }

    public void OnIEnable()
    {
        PlayerCollisionController.OrbCollected += ProcessOrbCollection;
    }

    public void OnIUpdate()
    {
        
    }

    public void OnILateUpdate() {

    }

    private void ProcessOrbCollection(OrbObject obj)
    {
        Debug.Log(obj.name);
        inventoryOrbs.Add(obj);
        OrbData orbData = obj.GetData();
        uiController.SetOrbsButtons(orbData);
    }
}
