using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingOrb : OrbGameObject<ChargingOrbData>, IEnableable, IUpdatable, IDisaable, IPickable<ChargingOrb>
{
   public void OnIDisable()
   {
      
   }

   public void OnIEnable()
   {
      
   }

   public void OnIUpdate()
   {
      
   }

   protected override void OnCollisionEnter(Collision collision)
   {
      
   }

   protected override void OnTriggerEneter(Collider collider)
   {
      
   }

   public ChargingOrb Pick() {
      return this;
   }
}