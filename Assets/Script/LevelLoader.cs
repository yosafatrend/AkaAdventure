using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f;

    public void LoadNextLevel(int index)
    {
        StartCoroutine(LoadLevel(index));
    }

    public void EndLevel(int index)
    {
        StartCoroutine(LoadEnd(index));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator LoadEnd(int levelIndex)
    {
        transition.SetTrigger("Tamat");

        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(levelIndex);
    }
}
