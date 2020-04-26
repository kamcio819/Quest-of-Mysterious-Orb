using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerOrbSlot : MonoBehaviour
{
    [SerializeField]
    private List<OrbObject> orbObjects;

    public List<OrbObject> OrbObjects { get => orbObjects; set => orbObjects = value; }


    public void SetActiveOrb()
    {
        var activeOrb = orbObjects.Find(x => x.gameObject.activeInHierarchy);
        var tabOfParticles = activeOrb.GetComponentsInChildren<ParticleSystem>(true);
        tabOfParticles[tabOfParticles.Length - 1].gameObject.SetActive(true);
    }

    public void DeactivateOrb()
    {
        var activeOrb = orbObjects.Find(x => x.gameObject.activeInHierarchy);
        var tabOfParticles = activeOrb.GetComponentsInChildren<ParticleSystem>(true);
        tabOfParticles[tabOfParticles.Length - 1].gameObject.SetActive(false);
    }

    public OrbObject GetCurrentOrb()
    {
        var activeOrb = orbObjects.Find(x => x.gameObject.activeInHierarchy);
        return activeOrb;
    }
}
