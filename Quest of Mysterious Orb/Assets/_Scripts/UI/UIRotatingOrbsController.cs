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
        playerOrbSlots[UnityEngine.Random.Range(0, playerOrbSlots.Count)].OrbObjects.ForEach( x => x.gameObject.SetActive(false));
        playerOrbSlots[UnityEngine.Random.Range(0, playerOrbSlots.Count)].OrbObjects.Find( x => x.GetType() == obj.GetType()).gameObject.SetActive(true);
    }
}
