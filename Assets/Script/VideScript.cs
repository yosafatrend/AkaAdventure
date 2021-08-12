using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideScript : MonoBehaviour
{
    private LevelLoader lvl;
    VideoPlayer video;

    void Awake()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver;
    }

    void Start()
    {
        lvl = GameObject.FindGameObjectWithTag("lvl").GetComponent<LevelLoader>();

    }


    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        lvl.LoadNextLevel(3);
    }
}
