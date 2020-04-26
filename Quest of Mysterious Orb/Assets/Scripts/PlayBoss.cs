using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBoss : MonoBehaviour
{
    private ArenaFilmController arenaFilmController = new ArenaFilmController();

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerObject>() != null)
        {
            arenaFilmController.PlayArena();
        }
    }
}
