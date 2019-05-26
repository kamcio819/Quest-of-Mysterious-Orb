using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using System;

public class CreditsScript : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;
    public float videoTime = 23f;


    // Use this for initialization


    void Start()
    {
        videoPlayer.time = 66;
        StartCoroutine(PlayVideo());
        videoPlayer.loopPointReached += LoopPoint;
    }

    private void LoopPoint(VideoPlayer source)
    {
        source.time = 66;
    }

    void Update() {
        
    }


    IEnumerator PlayVideo()
    {
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1f);
        while (!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
        audioSource.Play();
        yield return new WaitForSeconds(videoTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}