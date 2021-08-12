using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private LevelLoader lvl;

    public void Start()
    {
        lvl = GameObject.FindGameObjectWithTag("lvl").GetComponent<LevelLoader>();
    }
    public void PlayGame()
    {
        lvl.LoadNextLevel(1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
