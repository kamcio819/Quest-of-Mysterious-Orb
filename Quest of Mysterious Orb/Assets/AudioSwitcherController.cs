using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwitcherController : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;
    private void OnTriggerEnter(Collider other) {

        var enemy = other.GetComponent<EnemyObject>();
        if(enemy != null) {
            SoundManager.Instance.PlayCombatMusic();
        }
    }

    private void OnTriggerExit(Collider other) {

        if(Physics.OverlapBox( transform.position, GetComponent<BoxCollider>().size, transform.rotation , layerMask).Length == 0) {
            SoundManager.Instance.PlayCalmMusic();
        }	
    }
}
