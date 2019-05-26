using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerCollisionController : ExecutableController, IEnableable, IUpdatable, IDisaable, ILateUpdatable, IAwakable
{
   [SerializeField]
   private PlayerObject playerObject;
   public static Action<OrbObject> OrbCollected;

   [SerializeField]
   private UIController uIController;

   [SerializeField]
   private List<Renderer> renderers;

   private Shader normalShader;
   private Shader transparentShader;

   public void OnIAwake()
   {
        normalShader = Shader.Find("Standard");
        transparentShader = Shader.Find("Legacy Shaders/Diffuse");
   }


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
      uIController.DefeatInformation();
   }

   private void OnTriggerEnter(Collider other) {
      var pickedOrb = other.GetComponent<OrbObject>();
      if(pickedOrb != null) {
         var data = pickedOrb.Pick();
         if(OrbCollected != null) {
            OrbCollected(data);
         }
         SoundManager.Instance.PlaySound("LAG - Orb_pick", GetComponent<AudioSource>());
         pickedOrb.gameObject.SetActive(false);
      }

      var enemyCollided = other.GetComponent<EnemyObject>();
      if(enemyCollided != null) {
         SoundManager.Instance.PlaySound("LAG - Karyna_hit-003", GetComponent<AudioSource>());
         playerObject.HealthPlayer -= enemyCollided.GetData().EnemyDamage;
         GetDamage();
         uIController.RemoveHealthFromBar(playerObject.HealthPlayer);
         if(playerObject.HealthPlayer < 0f) {    
            Die();
         }
      }
   }

   private void GetDamage() {
      StartCoroutine(TransparencyToggle());
   }

   private IEnumerator TransparencyToggle() {
      for(float i = 0; i < 1.3f; i += Time.deltaTime) {
         for(int j = 0; j < renderers.Count; ++j) {
            renderers[j].material.shader = transparentShader;
         }
         yield return new WaitForEndOfFrame();
         for(int j = 0; j < renderers.Count; ++j) {
            renderers[j].material.shader = normalShader;
         }
         yield return new WaitForEndOfFrame();
      }
   }

   public void Hit(float v)
   {
      playerObject.HealthPlayer -= v;
      uIController.RemoveHealthFromBar(playerObject.HealthPlayer);
      if(playerObject.HealthPlayer < 0f) {    
         Die();
      }
   }

}
