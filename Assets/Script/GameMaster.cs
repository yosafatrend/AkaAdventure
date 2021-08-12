using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public Vector2 lastCheckPointPos;
    public int lifePoint;
    public int checkpoint;
    public Conservation convo;
    public Conservation convo2;
    public Conservation convoCheckpoint;
    public Conservation convoToilet;

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
        StartCutscene.isCurSceneOn = true;
        DialogueManager.StartConservation(convo);
    }

}
