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
      var activeOrb = orbObjects.FirstOrDefault( x => x.gameObject.activeInHierarchy );
      var tabOfParticles = activeOrb.GetComponentsInChildren<ParticleSystem>(true);
      tabOfParticles[tabOfParticles.Length - 1].gameObject.SetActive(true);
   }

   internal void DeactivateOrb()
   {
      var activeOrb = orbObjects.FirstOrDefault( x => x.gameObject.activeInHierarchy );
      var tabOfParticles = activeOrb.GetComponentsInChildren<ParticleSystem>(true);
      tabOfParticles[tabOfParticles.Length - 1].gameObject.SetActive(false);
   }
}
