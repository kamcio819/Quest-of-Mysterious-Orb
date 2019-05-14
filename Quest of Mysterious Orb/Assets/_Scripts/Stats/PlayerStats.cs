using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //Orb system
public class PlayerStats : MonoBehaviour
{

    public Orb[] AllOrbs;
    public Orb[] PlayerOrbs;
    private Inventory inventory;


    void Start()
{
    PlayerOrbs[0].id = AllOrbs[0].id;
    PlayerOrbs[0].icon = AllOrbs[0].icon;
    PlayerOrbs[0].name = AllOrbs[0].name;
    PlayerOrbs[0].description = AllOrbs[0].description;
    
    PlayerOrbs[1].id = AllOrbs[1].id;
    PlayerOrbs[1].icon = AllOrbs[1].icon;
    PlayerOrbs[1].name = AllOrbs[1].name;
    PlayerOrbs[1].description = AllOrbs[1].description;

    PlayerOrbs[2].id = AllOrbs[2].id;
    PlayerOrbs[2].icon = AllOrbs[2].icon;
    PlayerOrbs[2].name = AllOrbs[2].name;
    PlayerOrbs[2].description = AllOrbs[2].description;
}

     private void Update()
    //TEST ORBS
    {
        /*
        {
            if (transform.childCount <= 0)
            {
                inventory.isFull[i] = false;
            }
        } */

        if (Input.GetMouseButtonDown(0)) //Primary button
        UsedOrb(PlayerOrbs[0].id);
        if (Input.GetMouseButtonDown(1)) //Secondary button
        UsedOrb(PlayerOrbs[2].id);
        if (Input.GetMouseButtonDown(2)) //Middle button
        UsedOrb(PlayerOrbs[1].id);
    }

    void UsedOrb (int id)
    {
        switch (id)
        {
            case 1:
                print("Used orb 1");
                break;
            case 2:
                print("Used orb 2");
                break;
            case 3:
                print("Used orb 3");
                break;
            case 4:
                print("Used orb 4");
                break;
            default:
                print("Orb Error");
                break;
        }
    }

}