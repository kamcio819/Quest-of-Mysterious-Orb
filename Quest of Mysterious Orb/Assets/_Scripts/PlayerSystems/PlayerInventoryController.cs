using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventoryController : ExecutableController<InventoryData>, IEnableable, IUpdatable, IDisaable, ILateUpdatable, IAwakable
{
    [SerializeField]
    private List<OrbObject> inventoryOrbs = new List<OrbObject>();

    [SerializeField]
    private UIController uiController;

    [SerializeField]
    private UIRotatingOrbsController uIRotatingOrbsController;

    private OrbObject currentSelectedOrb;


    ///TODO: CHANGE CHANGEING CURRENT SELECTED ORB
    public List<OrbObject> InventoryOrbs { get => inventoryOrbs; set => inventoryOrbs = value; }
    public OrbObject CurrentSelectedOrb { get => inventoryOrbs.FirstOrDefault(v => v != null); set => currentSelectedOrb = value; }

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

    public void OnIAwake() {

    }

    private void ProcessOrbCollection(OrbObject obj)
    {
        inventoryOrbs.Add(obj);
        OrbData orbData = obj.GetData();
        uiController.SetOrbsButtons(orbData);
    }
}
