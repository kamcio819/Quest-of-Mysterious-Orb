using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOrb : OrbGameObject<BounceOrbData>, IEnableable, IUpdatable, IDisaable, IPickable<BounceOrb>
{
   public void OnIEnable()
   {
      
   }

   public void OnIUpdate()
   {
      
   }

   public void OnIDisable()
   {
      
   }
   protected override void OnCollisionEnter(Collision collision)
   {
      
   }

   protected override void OnTriggerEneter(Collider collider)
   {
      
   }

   public BounceOrb Pick() {
      return this;
   }
   
}