using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HomingOrb : OrbGameObject<HomingOrbData>, IEnableable, IUpdatable, IDisaable, IAwakable
{
   [SerializeField]
   private EnemyObject nearestEnemyObject;

   [SerializeField]
   private Rigidbody rigidbodyComponet;

   [SerializeField]
   private HomingClosestEnemy closestEnemy;

   private float timeTaken;

   public EnemyObject NearestEnemyObject { get => closestEnemy.ClosestEnemy; }

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
         if(NearestEnemyObject != null) {
            GetComponent<SphereCollider>().radius = 20f;
            timeTaken += Time.deltaTime;
            Vector3 direction = NearestEnemyObject.transform.position - transform.position;
            rigidbodyComponet.velocity += direction * 0.5f * Time.deltaTime;

            if(timeTaken > OrbData.CooldownTime) {
               isSpawned = false;
               gameObject.SetActive(false);
            }
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