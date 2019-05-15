using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackingController : ExecutableController<AttackingData>, IUpdatable, IEnableable, IDisaable, ILateUpdatable, IAwakable
{
   [SerializeField]
   private PlayerInventoryController playerInventoryController;

   [SerializeField]
   private Transform position;

   [SerializeField]
   private Transform playerBody;

   private List<OrbObject> activeOrbs;

   public void OnIAwake() {
      activeOrbs = playerInventoryController.InventoryOrbs;
   }

   public void OnIDisable()
   {
      InputController.mouseLeftButtonClicked -= SpawnOrb;
   }

   public void OnIEnable()
   {
      InputController.mouseLeftButtonClicked += SpawnOrb;
   }

   public void OnILateUpdate()
   {

   }

   public void OnIUpdate()
   {

   }

   public void SpawnOrb(bool isActive) {
      OrbObject orbToSpawn = playerInventoryController.CurrentSelectedOrb;
      if(orbToSpawn != null) {
         var spawnedOrb = Instantiate<OrbObject>(orbToSpawn,position.position, playerBody.rotation);
         spawnedOrb.isSpawned = true;
         playerInventoryController.InventoryOrbs.Remove(orbToSpawn);
      }
      
   }
}
