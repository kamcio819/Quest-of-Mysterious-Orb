using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MainMenuScript : MonoBehaviour  {

    [SerializeField]
    private VideoPlayer videoPlayer;

    public void PlayGame()
    {
        videoPlayer.Stop();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    { 
        videoPlayer.Stop();
        Debug.Log("QUIT!"); Application.Quit();
    }
}