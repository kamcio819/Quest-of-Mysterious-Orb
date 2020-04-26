using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ArenaFilmController : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;
    public float videoTime = 5f;

    public void PlayArena()
    {
        gameObject.SetActive(true);
        StartCoroutine(PlayVideo());
    }



    IEnumerator PlayVideo()
    {
        SoundManager.Instance.Pause();
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1f);
        while (!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        rawImage.color = new Color(255, 255, 255, 1);
        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
        audioSource.Play();
        yield return new WaitForSeconds(videoTime);
        gameObject.SetActive(false);
        SoundManager.Instance.Play();
    }
}