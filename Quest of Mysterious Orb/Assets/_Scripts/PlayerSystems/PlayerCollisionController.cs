using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : ExecutableController, IEnableable, IUpdatable, IDisaable, ILateUpdatable
{
   public static Action<OrbObject> OrbCollected;

   public void OnIDisable()
   {
      //throw new System.NotImplementedException();
   }

   public void OnIEnable()
   {
      //throw new System.NotImplementedException();
   }

   public void OnILateUpdate()
   {

   }

   public void OnIUpdate()
   {
      //throw new System.NotImplementedException();
   }

   private void OnCollisionEnter(Collision collision) {

   }

   private void OnTriggerEnter(Collider other) {
      Debug.Log(other.name);
      ChargingOrb charging = other.GetComponent<ChargingOrb>();
      if(OrbCollected != null) {
         OrbCollected(charging);
      }
   }
}
