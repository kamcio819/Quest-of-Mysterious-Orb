using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRotatingOrbsController : ExecutableController<MovementData>, IEnableable, IUpdatable, IDisaable, ILateUpdatable, IAwakable
{
    [SerializeField]
    private List<PlayerOrbSlot> playerOrbSlots;
    public void OnIDisable()
    {
    }

    public void OnIEnable()
    {
    }

    public void OnILateUpdate()
    {
    }

    public void OnIUpdate()
    {
        transform.RotateAround(transform.position, Vector3.up, 35f * Time.deltaTime);
    }

    public void OnIAwake() {
    }

    public void AddOrbToUI(OrbObject obj)
    {
        for(int i =0 ; i < playerOrbSlots.Count; ++i) {
            if(playerOrbSlots[i].OrbObjects.Find( x => x.GetType() == obj.GetType()).gameObject.activeInHierarchy) {
                return;
            }
        }
        int index = UnityEngine.Random.Range(0, playerOrbSlots.Count);
        playerOrbSlots[index].OrbObjects.ForEach( x => x.gameObject.SetActive(false));
        playerOrbSlots[index].OrbObjects.Find( x => x.GetType() == obj.GetType()).gameObject.SetActive(true);
    }

    public void EnableGrayOrbDefalut(OrbObject obj) {
        for(int i =0 ; i < playerOrbSlots.Count; ++i) {
            if(playerOrbSlots[i].OrbObjects.Find(x => x.GetType() == obj.GetType()).gameObject.activeInHierarchy) {
                playerOrbSlots[i].OrbObjects.Find(x => x.GetType() == obj.GetType()).gameObject.SetActive(false);
                playerOrbSlots[i].OrbObjects.Find(x => x.GetType() == typeof(GrayOrb)).gameObject.SetActive(true);
                return;
            }
        }
    }
}
