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

   [SerializeField]
   private OrbsController orbsController;

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
         spawnedOrb.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
         playerInventoryController.InventoryOrbs.Remove(orbToSpawn);
         orbsController.OrbsList.Add(spawnedOrb);
      }
      
   }
}
