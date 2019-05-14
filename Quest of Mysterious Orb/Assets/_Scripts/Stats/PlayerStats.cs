using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //Orb system
public class PlayerStats : MonoBehaviour
{

    public Orb[] AllOrbs;
    public Orb[] PlayerOrbs;
    private Inventory inventory;
    public GameObject OrbSlot1;
    public GameObject OrbSlot2;
    public GameObject OrbSlot3;

    void Start()
{
    PlayerOrbs[0].id = AllOrbs[0].id;
    PlayerOrbs[0].name = AllOrbs[0].name;
    //PlayerOrbs[0].description = AllOrbs[0].description;
    
    PlayerOrbs[1].id = AllOrbs[1].id;
    PlayerOrbs[1].name = AllOrbs[1].name;
    //PlayerOrbs[1].description = AllOrbs[1].description;

    PlayerOrbs[2].id = AllOrbs[2].id;
    PlayerOrbs[2].name = AllOrbs[2].name;
    //PlayerOrbs[2].description = AllOrbs[2].description;
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
        if (Input.GetKeyDown("3"))
            UsedOrb(PlayerOrbs[3].id);
    }

    void UsedOrb (int id)
    {
        switch (id)
        {
            case 0:
                print(OrbSlot1.name);
                foreach (Transform child in OrbSlot1.transform)
                {
                    var orbType = child.GetComponent<OrbObject>().OrbData.OrbType;
                    Debug.Log(orbType);
                    GameObject.Destroy(child.gameObject);
                }
                //Destroy(gameObject);
                break;
            case 1:
                print(OrbSlot2.name);
                foreach (Transform child in OrbSlot2.transform)
                {
                    var orbType = child.GetComponent<OrbObject>().OrbData.OrbType;
                    Debug.Log(orbType);
                    GameObject.Destroy(child.gameObject);
                }
                break;
            case 2:
                print(OrbSlot3.name);
                foreach (Transform child in OrbSlot3.transform)
                {
                    var orbType = child.GetComponent<OrbObject>().OrbData.OrbType;
                    Debug.Log(orbType);
                    GameObject.Destroy(child.gameObject);
                }
                break;
            case 3:
                print("Used orb 4");
                break;
            default:
                print("Orb Error");
                break;
        }
    }

}