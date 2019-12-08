using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventoryController : ExecutableController<InventoryData>, IEnableable, IUpdatable, IDisaable, ILateUpdatable, IAwakable
{
    [SerializeField]
    private List<OrbObject> inventoryOrbs;

    [SerializeField]
    private UIController uiController;

    [SerializeField]
    private UIRotatingOrbsController uIRotatingOrbsController;

    private OrbObject currentSelectedOrb;
    public List<OrbObject> InventoryOrbs { get => inventoryOrbs; set => inventoryOrbs = value; }
    public OrbObject CurrentSelectedOrb { get => GetCurrentSelectedOrb(); set => currentSelectedOrb = value; }

    public void OnIDisable()
    {
        PlayerCollisionController.OrbCollected -= ProcessOrbCollection;
    }

    public void OnIEnable()
    {
        PlayerCollisionController.OrbCollected += ProcessOrbCollection;
    }

    public void ResetOrbs()
    {
        //inventoryOrbs.Clear();
    }

    public void OnIUpdate() {}

    public void OnILateUpdate() {}

    public void OnIAwake() {}

    private void ProcessOrbCollection(OrbObject obj)
    {
        if(!inventoryOrbs.Find((x) => x.GetType() == obj.GetType())) {
           inventoryOrbs.Add(obj);
            uIRotatingOrbsController.AddOrbToUI(obj);
            OrbData orbData = obj.GetData();
            uiController.SetOrbsButtons(orbData); 
        }   
    }

    private OrbObject GetCurrentSelectedOrb() {
        var orbToCreate = uIRotatingOrbsController.GetActiveOrb();
        if(orbToCreate.GetType() == typeof(GrayOrb)) {
            return orbToCreate;
        }
        else {
            return inventoryOrbs.Find((x) => x.GetType() == orbToCreate.GetType());
        }
    }
}
