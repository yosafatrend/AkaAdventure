using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonvingBlockControl : MonoBehaviour
{
    private WaypointFollower wyp;
    [SerializeField]private AudioSource woshwosh;

    private void Start()
    {
        wyp = GetComponent<WaypointFollower>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            woshwosh.Play();
            wyp.enabled = true;
            StartCoroutine(Moving());
        }
    }

    IEnumerator Moving()
    {
        yield return new WaitForSeconds(2f);
        woshwosh.Stop();
        wyp.enabled = false;
    }
}
