using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerCollisionController : ExecutableController, IEnableable, IUpdatable, IDisaable, ILateUpdatable
{
   public static Action<OrbObject> OrbCollected;

   private List<OrbObject> orbObject = new List<OrbObject>();

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
      
   }

   private void OnCollisionEnter(Collision collision) {

   }

   private void OnTriggerEnter(Collider other) {
      orbObject.Add(other.GetComponent<GrayOrb>());
      orbObject.Add(other.GetComponent<BounceOrb>());
      orbObject.Add(other.GetComponent<ChargingOrb>());
      orbObject.Add(other.GetComponent<HomingOrb>());
      if(OrbCollected != null) {
         OrbCollected(orbObject.FirstOrDefault(v => v != null));
      }
      orbObject.Clear();
   }
}
