using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRotatingOrbsController : ExecutableController<MovementData>, IEnableable, IUpdatable, IDisaable, ILateUpdatable, IAwakable
{
    [SerializeField]
    private List<PlayerOrbSlot> playerOrbSlots;

    [SerializeField]
    private float angleRotation = 35f;

    private int index = 0;
    public void OnIDisable()
    {
        InputController.mouseScrollWheelMoved -= ChooseSpecificOrb;
    }

    public void OnIEnable()
    {
        InputController.mouseScrollWheelMoved += ChooseSpecificOrb;
    }

    public void OnILateUpdate() { }

    private void ChooseSpecificOrb(float deltaValue)
    {
        playerOrbSlots[index].DeactivateOrb();
        if (deltaValue > 0)
        {
            index = ((index + (int)deltaValue) % 3);
        }
        else
        {
            index = ((index - (int)deltaValue) % 3);
        }
        playerOrbSlots[index].SetActiveOrb();
    }

    public void OnIUpdate()
    {
        transform.RotateAround(transform.position, Vector3.up, angleRotation * Time.deltaTime);
    }

    public void OnIAwake()
    {
        playerOrbSlots[index].SetActiveOrb();
    }

    public void AddOrbToUI(OrbObject obj)
    {
        for (int i = 0; i < playerOrbSlots.Count; ++i)
        {
            if (playerOrbSlots[i].OrbObjects.Find(x => x.GetType() == obj.GetType()).gameObject.activeInHierarchy)
            {
                return;
            }
        }
        int index = UnityEngine.Random.Range(0, playerOrbSlots.Count);
        playerOrbSlots[index].OrbObjects.ForEach(x => x.gameObject.SetActive(false));
        playerOrbSlots[index].OrbObjects.Find(x => x.GetType() == obj.GetType()).gameObject.SetActive(true);
    }

    public OrbObject GetActiveOrb()
    {
        return playerOrbSlots[index].GetCurrentOrb();
    }

    public void EnableGrayOrbDefalut(OrbObject obj)
    {
        for (int i = 0; i < playerOrbSlots.Count; ++i)
        {
            if (playerOrbSlots[i].OrbObjects.Find(x => x.GetType() == obj.GetType()).gameObject.activeInHierarchy)
            {
                playerOrbSlots[i].OrbObjects.Find(x => x.GetType() == obj.GetType()).gameObject.SetActive(false);
                playerOrbSlots[i].OrbObjects.Find(x => x.GetType() == typeof(GrayOrb)).gameObject.SetActive(true);
                return;
            }
        }
    }
}
