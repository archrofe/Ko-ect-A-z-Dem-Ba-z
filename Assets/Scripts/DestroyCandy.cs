using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DestroyCandy : MonoBehaviour
{

    public int destroyTimer = 30;

	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, destroyTimer);
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}
}
