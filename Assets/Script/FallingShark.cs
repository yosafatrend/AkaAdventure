using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FallingShark : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private ParticleSystem watersplash;
    [SerializeField] private AudioSource cempulngwater;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 6f;

    private bool isTrigger = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(WaterEffect());
            isTrigger = true;
        }
    }

    private void Update()
    {
        if (isTrigger)
        {
            if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = 0;
                }
            }
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
        }
    }

    IEnumerator WaterEffect()
    {
        yield return new WaitForSeconds(0.8f);

        cempulngwater.Play();
        watersplash.Play();
    }
}
