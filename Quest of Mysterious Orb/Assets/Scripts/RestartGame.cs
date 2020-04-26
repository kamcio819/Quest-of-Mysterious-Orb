using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    [SerializeField]
    private SpawnManager spawnManager;

    [SerializeField]
    private Image uiHealth;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            uiHealth.fillAmount = 1;
            spawnManager.SpawnPlayer();
            this.gameObject.SetActive(false);
        }
    }
}
