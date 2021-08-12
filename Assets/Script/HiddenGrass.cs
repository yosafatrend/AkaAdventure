using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class HiddenGrass : MonoBehaviour
{
    [SerializeField] private AudioSource hit;

    private void Start()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!gameObject.transform.GetChild(0).gameObject.active)
            {
                hit.Play();
            }
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
