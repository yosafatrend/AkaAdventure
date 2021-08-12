using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcRodoMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    private Animator anim;
    public Conservation convo;

    [SerializeField] private float speed = 6f;

    private bool isTrigger = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Invoke(nameof(Walk), 4f);
            Invoke(nameof(Talk), 7f);

        }
    }

    private void Update()
    {
        if (isTrigger)
        {
            anim.SetBool("RodoriWalk", true);
            if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = 0;
                    anim.SetBool("RodoriWalk", false);
                }
            }
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
        }
    }

    private void Walk()
    {
        isTrigger = true;
    }

    private void Talk()
    {
        DialogueManager.StartConservation(convo);
    }
}
