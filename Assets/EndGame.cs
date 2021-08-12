using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private LevelLoader lvl;
    // Start is called before the first frame update
    private void Start()
    {
        lvl = GameObject.FindGameObjectWithTag("lvl").GetComponent<LevelLoader>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            lvl.EndLevel(0);
        }
    }
}
