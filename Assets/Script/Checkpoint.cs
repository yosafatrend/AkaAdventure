using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Checkpoint : MonoBehaviour
{
    private GameMaster gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gm.lastCheckPointPos = transform.position;
            gm.checkpoint++;
            if (gm.checkpoint == 3)
            {
                StartCutscene.isCurSceneOn = true;
                DialogueManager.StartConservation(gm.convoCheckpoint);
            }
        }
    }

}
