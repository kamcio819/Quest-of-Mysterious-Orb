using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerCollisionController : ExecutableController, IEnableable, IUpdatable, IDisaable, ILateUpdatable
{
   public static Action<OrbObject> OrbCollected;

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
      var pickedOrb = other.GetComponent<OrbObject>().Pick();
      if(pickedOrb != null) {
         if(OrbCollected != null) {
            OrbCollected(pickedOrb);
         }
      }
   }
}
