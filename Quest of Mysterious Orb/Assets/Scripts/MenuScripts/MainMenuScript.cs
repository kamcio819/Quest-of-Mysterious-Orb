using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class MainMenuScript : MonoBehaviour
{

    [SerializeField]
    private VideoPlayer videoPlayer;

    [SerializeField]
    private Image loadingScene;

    [SerializeField]
    private Text loadingSceneText;

    public void PlayGame()
    {
        videoPlayer.Stop();
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        asyncOperation.allowSceneActivation = false;
        while (!asyncOperation.isDone)
        {
            loadingScene.fillAmount = asyncOperation.progress;
            loadingSceneText.text = ((int)(asyncOperation.progress * 100f)).ToString() + "#";
            if (asyncOperation.progress >= 0.90f)
            {
                asyncOperation.allowSceneActivation = true;
            }

            yield return new WaitForSeconds(0.15f);
        }
    }

    public void QuitGame()
    {
        videoPlayer.Stop();
        Debug.Log("QUIT!"); Application.Quit();
    }
}