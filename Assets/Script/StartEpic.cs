using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEpic : MonoBehaviour
{
    public static bool isCurSceneOn;
    public Animator camAnim;
    private GameMaster gm;
    [SerializeField] private String cutsceneName;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCutscene.isCurSceneOn = true;
            if (cutsceneName == "cutscene1")
            {
                DialogueManager.StartConservation(gm.convoToilet);
            }
            if (cutsceneName == "cutscene3")
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
            camAnim.SetBool(cutsceneName, true);
        }
    }

    private void StopCutscene()
    {
        isCurSceneOn = false;
        camAnim.SetBool(cutsceneName, false);
        Destroy(gameObject);
    }
}
