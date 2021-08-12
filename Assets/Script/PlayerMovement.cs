using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;
    private MovementState state;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private ParticleSystem dust;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private AudioSource footstep;
    [SerializeField] private AudioSource jumpsfx;
    [SerializeField] private AudioSource landing;

    private bool isDoubleJump = false;
    private bool isFall = false;

    private float hangCounter;
    private float hangTime = .2f;

    private enum MovementState { idle, running, jumping, falling }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!StartCutscene.isCurSceneOn)
        {
            dirX = CrossPlatformInputManager.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

            if (IsGrounded())
            {
                hangCounter = hangTime;
            }
            else
            {
                hangCounter -= Time.deltaTime;
            }

            if (CrossPlatformInputManager.GetButtonDown("Jump") && hangCounter > 0f)
            {
                jumpsfx.Play();
                dust.Play();
                isDoubleJump = true;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            else if (CrossPlatformInputManager.GetButtonDown("Jump") && isDoubleJump)
            {
                jumpsfx.Play();
                isDoubleJump = false;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }

            if (rb.velocity.x != 0 && IsGrounded())
            {
                if (!footstep.isPlaying)
                {
                    footstep.Play();
                }
            }
            else
            {
                footstep.Stop();
            }

            if (isFall)
            {
                landing.Play();
                isFall = false;
            }

            UpdateAnimation();
        }
        else
        {
            anim.SetInteger("state", (int)MovementState.idle);
            footstep.Stop();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isFall = true;

            dust.Play();
        }


    }

    private void UpdateAnimation()
    {
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;

        }
        else
        {
            state = MovementState.idle;

        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    public void Footstep()
    {
        footstep.Play();
    }
}
