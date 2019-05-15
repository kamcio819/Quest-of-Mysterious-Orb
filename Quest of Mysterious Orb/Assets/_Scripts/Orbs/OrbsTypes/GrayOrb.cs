using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayOrb : OrbGameObject<GrayOrbData>, IEnableable, IUpdatable, IDisaable, IPickable<GrayOrb>
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

   public GrayOrb Pick() {
      return this;
   }
}