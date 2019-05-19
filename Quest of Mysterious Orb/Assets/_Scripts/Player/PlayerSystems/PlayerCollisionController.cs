using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerCollisionController : ExecutableController, IEnableable, IUpdatable, IDisaable, ILateUpdatable
{
   [SerializeField]
   private PlayerObject playerObject;
   public static Action<OrbObject> OrbCollected;

   [SerializeField]
   private UIController uIController;

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

   private void Die()
   {
      //TODO
   }

   private void OnTriggerEnter(Collider other) {
      var pickedOrb = other.GetComponent<OrbObject>();
      if(pickedOrb != null) {
         var data = pickedOrb.Pick();
         if(OrbCollected != null) {
            OrbCollected(data);
         }
         pickedOrb.gameObject.SetActive(false);
      }

      var enemyCollided = other.GetComponent<EnemyObject>();
      if(enemyCollided != null) {
         playerObject.HealthPlayer -= enemyCollided.GetData().EnemyDamage;
         uIController.RemoveHealthFromBar(playerObject.HealthPlayer);
         if(playerObject.HealthPlayer < 0f) {    
            Die();
         }
      }
   }
}
