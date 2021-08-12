using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FallingBlock2 : MonoBehaviour
{
    [SerializeField] private AudioSource fall;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            fall.Play();
            CinemachineShake.Instance.ShakeCamera(5f, 1f);
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
