using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    public Conservation convo;

    public void StartConvo()
    {
        DialogueManager.StartConservation(convo);
    }
}
