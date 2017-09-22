using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsWin : MonoBehaviour
{
    public Transform birdEndPos;
    public float birdSpeed;

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        float step = birdSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, birdEndPos.position, step);
    }
}
