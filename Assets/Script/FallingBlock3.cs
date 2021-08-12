using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FallingBlock3 : MonoBehaviour
{
    [SerializeField] private AudioSource fall;
    private int childnumb = 0;
    private bool isTrigger = false;

    private void Update()
    {
        if (isTrigger)
        {
            //if (childnumb < this.gameObject.transform.childCount)
            //{
            //    StartCoroutine(FallingBlock());
            //    Debug.Log(childnumb);
            //}
            //else if (childnumb >= 6)
            //{
            //    return;
            //}
            StartCoroutine(FallingBlock());
            isTrigger = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isTrigger = true;
        }
    }

    IEnumerator FallingBlock()
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            yield return new WaitForSeconds(1f);
            fall.Play();
            try
            {
                gameObject.transform.GetChild(childnumb).gameObject
                .GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
            catch (Exception e)
            {
            }
            CinemachineShake.Instance.ShakeCamera(5f, 1f);
            childnumb++;
        }
    }
}
