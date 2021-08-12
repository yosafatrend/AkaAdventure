using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpear : MonoBehaviour
{
    [SerializeField] private AudioSource fall;
    [SerializeField] private ParticleSystem poison;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            poison.Play();
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            fall.Play();
            CinemachineShake.Instance.ShakeCamera(5f, 1f);
        }
    }
}
