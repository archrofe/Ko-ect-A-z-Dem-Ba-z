using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public Transform pos1; // down!
    public Transform pos2; // right!
    public Transform pos3; // left!
    public float pos1Speed;

    public GameObject bossSpawner1;
    public GameObject bossSpawner2;
    public GameObject bossSpawner3;
    public GameObject bossSpawner4;
    public GameObject bossEvilSpawner1;
    public GameObject bossEvilSpawner2;
    public GameObject bossEvilSpawner3;
    public GameObject bossEvilSpawner4;
    public GameObject bossEvilSpawner5;
    public GameObject bossEvilSpawner6;

    public GameObject boss2;
    public GameObject boss3;
    public GameObject boss4;

    private bool bossStarted = false; // just used for Boss downward movement to Pos1 at start

    private bool bossRightDone = false;

    public int hitCount = 0;
    public int evilCount = 0;

    public AudioSource bossMusic;

    public GameObject bossClouds;

    // Use this for initialization
    void Start()
    {
        boss2.SetActive(false);
        boss3.SetActive(false);
        boss4.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (bossStarted == false)
        {
            GoToPos1();

            if (transform.position == pos1.position)
            {
                bossSpawner1.SetActive(true);
                bossSpawner2.SetActive(true);
                bossStarted = true;
            }
        }

        if (bossStarted == true)
        {
            if (bossRightDone == false)
            {
                GoRight();

                if (transform.position == pos2.position)
                {
                    bossRightDone = true;
                }
            }

            if (bossRightDone == true)
            {
                GoLeft();

                if (transform.position == pos3.position)
                {
                    bossRightDone = false;
                }
            }
        }

        HitDestroy();

        if (Input.GetKeyDown(KeyCode.F10))
        {
            hitCount = hitCount + 1;

            if (hitCount >= 3)
            {
                evilCount = evilCount + 1;
            }
        }
    }

    void GoToPos1()
    {
        transform.position = Vector3.MoveTowards(transform.position, pos1.position, pos1Speed * Time.deltaTime);
    }

    void GoRight()
    {
        transform.position = Vector3.MoveTowards(transform.position, pos2.position, pos1Speed * Time.deltaTime);
    }

    void GoLeft()
    {
        transform.position = Vector3.MoveTowards(transform.position, pos3.position, pos1Speed * Time.deltaTime);
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.CompareTag("Boss Candy"))
        {
            Debug.Log("Boss Candy hit Boss!");
            hitCount = hitCount + 1;
            Debug.Log("hitCount = " + hitCount);
        }

        if (other.gameObject.CompareTag("Boss Evil Candy"))
        {
            evilCount = evilCount + 1;
        }
    }

    void HitDestroy()
    {
        if (hitCount == 1)
        {
            boss2.SetActive(true);
            bossSpawner3.SetActive(true);
            bossSpawner4.SetActive(true);
        }

        if (hitCount == 2)
        {
            boss3.SetActive(true);
            pos1Speed = 8;
        }

        if (hitCount == 3)
        {
            bossMusic.gameObject.SetActive(false);

            boss2.SetActive(false);
            boss3.SetActive(false);
            boss4.SetActive(true);

            bossSpawner1.SetActive(false);
            bossSpawner2.SetActive(false);
            bossSpawner3.SetActive(false);
            bossSpawner4.SetActive(false);

            pos1Speed = 12;
            bossEvilSpawner1.SetActive(true);
            bossEvilSpawner2.SetActive(true);
            bossEvilSpawner3.SetActive(true);
            bossEvilSpawner4.SetActive(true);
            bossEvilSpawner5.SetActive(true);
            bossEvilSpawner6.SetActive(true);

            bossClouds.SetActive(true);
        }

        if (evilCount == 3)
        {
            SceneManager.LoadScene(3);
            Debug.Log("LoadScene 3");
        }
    }
}
