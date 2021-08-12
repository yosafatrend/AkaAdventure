using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpShark : MonoBehaviour
{

    private Rigidbody2D rb;
    private bool isCollide = false;
    private int oneTime = 0;

    [SerializeField] private float dirx = -0.3f;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float jumpForce = 9f;
    [SerializeField] private ParticleSystem watersplash;
    [SerializeField] private AudioSource outwater;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollide && oneTime == 1)
        {
            outwater.Play();
            watersplash.Play();
            rb.velocity = new Vector2(dirx * moveSpeed, rb.velocity.y);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            StartCoroutine(MoveBack());
            isCollide = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isCollide = true;
            oneTime++;
        }
    }

    IEnumerator MoveBack()
    {
        yield return new WaitForSeconds(2);

       rb.velocity = new Vector2(1f * 12f, rb.velocity.y);
    }
}
