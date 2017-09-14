using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform pos1; // down!
    public Transform pos2; // right!
    public Transform pos3; // left!
    public float pos1Speed;

    public bool bossStarted = false;
    public bool bossFirstMove = false;

    public GameObject bossSpawner1;
    public GameObject bossSpawner2;

	// Use this for initialization
	void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
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
            if (bossFirstMove == false)
            {
                GoRight();
                bossFirstMove = true;
            }

            if (bossFirstMove == true)
            {
                if (transform.position == pos2.position)
                {
                    GoLeft();
                }

                if (transform.position == pos3.position)
                {
                    GoRight();
                }
            }
        }

        /*if (bossStarted == false)
        {
            GoToPos1();

            if (transform.position == pos1.position)
            {
                bossStarted = true;
            }
        }

        if (bossStarted == true)
        {
            Debug.Log("bossStarted == true");
        }*/
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
}
