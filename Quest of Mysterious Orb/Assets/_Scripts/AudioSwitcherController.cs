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
    }
}
