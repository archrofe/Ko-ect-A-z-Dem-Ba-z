using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform pos1; // down!
    public float pos1Speed;

    public bool bossStarted = false;

	// Use this for initialization
	void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        GoToPos1();
        
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


}
