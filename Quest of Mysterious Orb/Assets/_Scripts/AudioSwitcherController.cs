using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwitcherController : MonoBehaviour
{
    [SerializeField]
    private SoundManager soundManager;

    [SerializeField]
    private LayerMask layerMask;

    private void Update()
    {
        if(Physics.OverlapBox(transform.position, GetComponent<BoxCollider>().size, transform.rotation, layerMask) != null)
        {
            if (Physics.OverlapBox(transform.position, GetComponent<BoxCollider>().size, transform.rotation, layerMask).Length != 0)
                    {
                soundManager.PlayCombatMusic();
                    }
            else
                    {
                soundManager.PlayCalmMusic();
                    }
        }
        else
        {
            soundManager.PlayCalmMusic();
        }
        
        /*
        private void OnTriggerEnter(Collider other) {

            Debug.Log("XD");
            var enemy = other.GetComponent<EnemyObject>();
            if(enemy != null) {
                SoundManager.Instance.PlayCombatMusic();
            }
        }

        private void OnTriggerExit(Collider other) {

            for(int i = 0; i < Physics.OverlapBox(transform.position, GetComponent<BoxCollider>().size, transform.rotation, layerMask).Length; ++i)
            {
                Debug.Log(Physics.OverlapBox(transform.position, GetComponent<BoxCollider>().size, transform.rotation, layerMask)[i].name);
            }
            if(Physics.OverlapBox( transform.position, GetComponent<BoxCollider>().size, transform.rotation , layerMask).Length == 0) {
                SoundManager.Instance.PlayCalmMusic();
            }	
        }*/
    }
}
