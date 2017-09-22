using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform pos1; // down!
    public Transform pos2; // right!
    public Transform pos3; // left!
    public float pos1Speed;

    public GameObject bossSpawner1;
    public GameObject bossSpawner2;

    private bool bossStarted = false;
    private bool bossFirstMoveDone = false;

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

            /*if (transform.position == pos2.position)
            {
                GoLeft();
            }*/
        }

        if (bossStarted == true)
        {
            if (bossFirstMoveDone == false)
            {
                GoRight();
            }


            if (transform.position == pos2.position)
            {
                GoLeft();
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

    void OnTriggerEnter2D (Collider2D other)
    {
        /*if (other.gameObject.CompareTag("Boss Right"))
        {
            GoLeft();
        }

        if (other.gameObject.CompareTag("Boss Left"))
        {
            GoRight();
        }*/

        if (other.gameObject.CompareTag("Boss Candy"))
        {
            Debug.Log("Boss Candy hit Boss!");
        }
    }
}
