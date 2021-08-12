using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private GameObject effect;
    private Rigidbody2D rb;
    private Renderer rd;
    private GameMaster gm;
    private LevelLoader lvl;
    [SerializeField] private AudioSource splat;
    [SerializeField] private AudioSource drowned;
    [SerializeField] private TextMeshProUGUI life;
    private bool FallDie = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rd = GetComponent<Renderer>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        lvl = GameObject.FindGameObjectWithTag("lvl").GetComponent<LevelLoader>();
        life.text = "Life: " + gm.lifePoint;
        transform.position = gm.lastCheckPointPos;

        if (gm.lifePoint == 2)
        {
            StartCutscene.isCurSceneOn = true;
            DialogueManager.StartConservation(gm.convo2);
        }
    }

    private void Update()
    {
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();

            StartCoroutine(RestartLevel());
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("end"))
        {
            Die();
            StartCoroutine(RestartLevel());
        }
        if (collision.gameObject.CompareTag("scene"))
        {
            lvl.LoadNextLevel(2);
            Destroy(GameObject.Find("BGM"));
            gm.lastCheckPointPos = new Vector2(-5f, 0.54f);
        }
        if (collision.gameObject.CompareTag("water"))
        {
            DieWater();
            StartCoroutine(RestartLevel());
        }
    }

    private void Die()
    {
        gm.lifePoint--;

        splat.Play();
        CinemachineShake.Instance.ShakeCamera(5f, .1f);
        Instantiate(effect, transform.position, Quaternion.identity);
        rd.enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    private void DieWater()
    {
        gm.lifePoint--;

        drowned.Play();
        rd.enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    IEnumerator RestartLevel()
    {
        life.text = "Life: " + gm.lifePoint;


        yield return new WaitForSeconds(2);

        StartCutscene.isCurSceneOn = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
