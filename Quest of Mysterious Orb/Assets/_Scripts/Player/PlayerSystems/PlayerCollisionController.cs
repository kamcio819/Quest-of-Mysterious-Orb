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
      var enemyCollided = collision.collider.GetComponent<EnemyGameObject>();
      playerObject.PlayerData.Health -= enemyCollided.EnemyData.EnemyDamage;
      if(playerObject.PlayerData.Health < 0f) {
         uIController.RemoveHealthFromBar(enemyCollided.EnemyData.EnemyDamage);
         Die();
      }
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

   }
}
