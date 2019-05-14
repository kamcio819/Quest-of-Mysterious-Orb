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
    public int i;

    void Start()
{
    PlayerOrbs[0].id = AllOrbs[0].id;
    PlayerOrbs[0].name = AllOrbs[0].name;
    
    PlayerOrbs[1].id = AllOrbs[1].id;
    PlayerOrbs[1].name = AllOrbs[1].name;

    PlayerOrbs[2].id = AllOrbs[2].id;
    PlayerOrbs[2].name = AllOrbs[2].name;

    inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

     private void Update()

    {


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
                
                foreach (Transform child in OrbSlot1.transform)
                {
                    var orbType = child.GetComponent<OrbObject>().OrbData.OrbType;
                    Debug.Log(orbType);
                    GameObject.Destroy(child.gameObject);
                    
                }
                inventory.isFull[0] = false;
                break;
            case 1:
                
                foreach (Transform child in OrbSlot2.transform)
                {
                    var orbType = child.GetComponent<OrbObject>().OrbData.OrbType;
                    Debug.Log(orbType);
                    GameObject.Destroy(child.gameObject);
                    
                }
                inventory.isFull[1] = false;
                break;
            case 2:
                
                foreach (Transform child in OrbSlot3.transform)
                {
                    var orbType = child.GetComponent<OrbObject>().OrbData.OrbType;
                    Debug.Log(orbType);
                    GameObject.Destroy(child.gameObject);
                    
                }
                inventory.isFull[2] = false;
                break;
            default:
                print("Orb Error");
                break;
        }
    }

}