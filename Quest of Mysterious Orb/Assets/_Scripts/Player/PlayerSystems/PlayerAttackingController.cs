using System;
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

   [SerializeField]
   private UIRotatingOrbsController uIRotatingOrbsController;

   [SerializeField]
   private Animator playerAnimator;

   private List<OrbObject> activeOrbs;

   public void OnIAwake() {
      activeOrbs = playerInventoryController.InventoryOrbs;
   }

   public void OnIDisable()
   {
      InputController.mouseLeftButtonClicked -= SpawnOrb;
      InputController.mouseLeftButtonClicked -= AnimateShoot;
   }

   public void OnIEnable()
   {
      InputController.mouseLeftButtonClicked += SpawnOrb;
      InputController.mouseLeftButtonClicked += AnimateShoot;
   }

   private void AnimateShoot(bool obj)
   {
      playerAnimator.SetTrigger("Shoot");
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
         var spawnedOrb = MyObjectPoolManager.Instance.GetObject(orbToSpawn.GetType().Name, true);
         spawnedOrb.transform.position = position.position;
         spawnedOrb.transform.rotation = playerBody.rotation;
         spawnedOrb.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
         playerInventoryController.InventoryOrbs.Remove(orbToSpawn);
         orbsController.OrbsList.Add(spawnedOrb.GetComponent<OrbObject>());
         uIRotatingOrbsController.EnableGrayOrbDefalut(spawnedOrb.GetComponent<OrbObject>());
         spawnedOrb.GetComponent<OrbObject>().isSpawned = true;
      }
      
   }
}
