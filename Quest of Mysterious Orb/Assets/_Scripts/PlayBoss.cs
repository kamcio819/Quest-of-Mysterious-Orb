using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBoss : MonoBehaviour
{
    private ArenaFilmController arenaFilmController = new ArenaFilmController();

    private void Start() {
        GameObject arenaFilmUI = GameObject.Find("ArenaFilm");
        arenaFilmController = arenaFilmUI.GetComponent<ArenaFilmController>();
        arenaFilmUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<PlayerObject>() != null) {
            arenaFilmController.PlayArena();
        }
    }
}
