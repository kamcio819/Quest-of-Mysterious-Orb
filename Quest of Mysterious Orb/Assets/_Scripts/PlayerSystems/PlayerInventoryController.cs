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
    private GrayOrb grayOrb;

    [SerializeField]
    private OrbsController orbsController;

    private OrbObject currentSelectedOrb;

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
        // for(int i = 0; i < 3; ++i) {
        //     inventoryOrbs.Add(grayOrb);
        // }
    }

    private void ProcessOrbCollection(OrbObject obj)
    {
        orbsController.OrbsList.Add(obj);
        inventoryOrbs.Add(obj);
        OrbData orbData = obj.GetData();
        uiController.SetOrbsButtons(orbData);
    }
}
