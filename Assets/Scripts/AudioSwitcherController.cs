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
        Collider[] overLap = Physics.OverlapBox(transform.position, GetComponent<BoxCollider>().size, transform.rotation, layerMask);
        if (overLap != null)
        {
            if (overLap.Length != 0)
            {
                soundManager.playCombat = true;
                soundManager.playCalm = false;
            }
            else
            {
                soundManager.playCombat = false;
                soundManager.playCalm = true;
            }
        }
        else
        {
            soundManager.playCombat = false;
            soundManager.playCalm = true;
        }
    }
}
