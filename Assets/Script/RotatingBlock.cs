using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBlock : MonoBehaviour
{
    private int z = 0;
    private bool isFall = false;
    [SerializeField] private ParticleSystem dust;
    [SerializeField] private AudioSource fall;
    [SerializeField] private AudioSource woosh;

    private WaypointFollower wyp;

    void Start()
    {
        wyp = GetComponent<WaypointFollower>();
    }

    // Update is called once per frame
    void Update()
    {
        //  transform.Rotate(Vector3.forward * 5 * Time.deltaTime);
        if (isFall == true)
        {
            if (z >= -25)
            {
                transform.eulerAngles = new Vector3(0, 0, z);
                z--;

            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (isFall == false)
            {
                StartCoroutine(MoveBlock());
                StartCoroutine(DustPlay());
                StartCoroutine(Gone());
                gameObject.tag = "Trap";
                isFall = true;
            }

        }
    }

    IEnumerator MoveBlock()
    {
        yield return new WaitForSeconds(2);
        woosh.Play();
        wyp.enabled = true;
    }

    IEnumerator DustPlay()
    {
        yield return new WaitForSeconds(1.3f);
        CinemachineShake.Instance.ShakeCamera(5f, .1f);
        fall.Play();
        dust.Play();
    }

    IEnumerator Gone()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
