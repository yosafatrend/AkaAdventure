using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBall : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isGround = false;
    private bool isTrigger = false;
    [SerializeField] private float dirx = -0.3f;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float jumpForce = 9f;
    [SerializeField] private AudioSource fallsfx;
    [SerializeField] private AudioSource rolling;
    private int bounce = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGround && bounce <= 1)
        {
            rb.velocity = new Vector2(dirx * moveSpeed, rb.velocity.y);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            fallsfx.Play();

            StartCoroutine(MoveBack());
            CinemachineShake.Instance.ShakeCamera(5f, .1f);

            isGround = false;
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            bounce++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            rb.bodyType = RigidbodyType2D.Dynamic; 
        }
    }

    IEnumerator MoveBack()
    {
        yield return new WaitForSeconds(3);

        rolling.Play();
        rb.velocity = new Vector2(1f * 12f, rb.velocity.y);
    }
}
