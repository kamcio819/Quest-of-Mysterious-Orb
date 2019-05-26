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
        if(overLap != null)
        {
            if (overLap.Length != 0)
            {
                Debug.Log("HIT");
                Debug.Log(overLap[0].name);
                soundManager.playCombat = true;
                soundManager.playCalm = false;
            }
            else
            {
                Debug.Log("NOTHIGN");
                soundManager.playCombat = false;
                soundManager.playCalm = true;
            }
        }
        else
        {
            Debug.Log("NOTHIGN");
            soundManager.playCombat = false;
            soundManager.playCalm = true;
        }
    }
}
