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

    private bool bossStarted = false; // just used for Boss downward movement to Pos1 at start

    private bool bossRightDone = false;

    public int hitCount = 0;

    // Use this for initialization
    void Start()
    {

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

    void OnTriggerExit2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("Boss Candy"))
        {
            Debug.Log("Boss Candy hit Boss!");
            hitCount = hitCount + 1;
            Debug.Log("hitCount = " + hitCount);
        }
    }

    void HitDestroy()
    {
        if (hitCount >= 1)
        {
            SceneManager.LoadScene(3);
            Debug.Log("LoadScene 3");
        }
    }
}
