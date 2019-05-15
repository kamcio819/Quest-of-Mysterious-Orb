using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : ExecutableController, IEnableable, IUpdatable, IDisaable
{
   [SerializeField]
   private List<OrbObject> orbsCollected = new List<OrbObject>();

   public void OnIDisable()
   {
      //throw new System.NotImplementedException();
   }

   public void OnIEnable()
   {
      //throw new System.NotImplementedException();
   }

   public void OnIUpdate()
   {
      //throw new System.NotImplementedException();
   }

   private void OnCollisionEnter(Collision collision) {

   }

   private void OnTriggerEnter(Collider other) {
      ChargingOrb charging = other.GetComponent<ChargingOrb>();
      orbsCollected.Add(charging);
   }
}
