using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HomingOrb : OrbGameObject<HomingOrbData>, IEnableable, IUpdatable, IDisaable, IAwakable
{
   [SerializeField]
   private EnemyObject nearestEnemyObject;

   [SerializeField]
   private Rigidbody rigidbodyComponet;

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
         GetComponent<SphereCollider>().isTrigger = false;
         GetComponent<SphereCollider>().radius = 20f;
         timeTaken += Time.deltaTime;
         Vector3 direction = nearestEnemyObject.transform.position - transform.position;
         rigidbodyComponet.velocity += direction * 0.5f * Time.deltaTime;

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
      gameObject.SetActive(false);
   }

   public override OrbObject Pick() {
      return this;
   }

   public void OnIUpdate()
   {
      
   }
}