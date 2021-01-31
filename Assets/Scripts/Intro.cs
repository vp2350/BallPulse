using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Intro : MonoBehaviour
{
    VideoPlayer video;

    void Start()
    {
        video = GetComponent<VideoPlayer>();
        //video.Play();
        video.loopPointReached += OnMovieEnded;
    }

    void OnMovieEnded(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(1);
    }
}