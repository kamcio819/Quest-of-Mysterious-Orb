using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayOrb : OrbGameObject<GrayOrbData>, IEnableable, IUpdatable, IDisaable, IAwakable
{
   private float timeTaken;

   public void OnIAwake() {
      timeTaken = 0f;
   }
   public void OnIDisable()
   {
      
   }

   public void OnIEnable()
   {
      
   }

   private void OnEnable() {
      timeTaken = 0f;
   }

   public void Update()
   {
      if(isSpawned) {
         timeTaken += Time.deltaTime;
         Vector3 newPos = transform.position;
         newPos += transform.forward * (OrbData as GrayOrbData).MovingSpeed * 3f * Time.deltaTime;
         transform.position = newPos;
         if(timeTaken > OrbData.CooldownTime) {
            isSpawned = false;
            gameObject.SetActive(false);
         }
      }
   }

   protected override void OnCollisionEnter(Collision collision)
   {
      base.OnCollisionEnter(collision);
   }
   protected override void OnTriggerEnter(Collider collider)
   {
      base.OnTriggerEnter(collider);
   }

   public override OrbObject Pick() {
      return this;
   }

   public void OnIUpdate()
   {
      
   }
}