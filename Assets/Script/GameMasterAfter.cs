using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameMasterAfter : MonoBehaviour
{
    private static GameMasterAfter instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //StartCutscene.isCurSceneOn = true;
        //DialogueManager.StartConservation(convo);
    }

}
