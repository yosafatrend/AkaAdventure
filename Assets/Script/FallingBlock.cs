using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FallingBlock : MonoBehaviour
{
    [SerializeField] private ParticleSystem dust;
    [SerializeField] private AudioSource fallsfx;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            gameObject.tag = "Trap";
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            fallsfx.Play();
            dust.Play();
        }


    }
}
