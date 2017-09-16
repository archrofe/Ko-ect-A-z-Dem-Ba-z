using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravCatcher : MonoBehaviour
{
    public Transform gravityBall;
    public float speed = 100;

    //public float spawnRadius = 5;

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void Catch()
    {
        float speedDelta = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, gravityBall.position, speedDelta);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Gravity Ball"))
        {
            Catch();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Gravity Ball"))
        {
            Catch();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gravity Ball"))
        {
            Catch();
        }
    }

    /*void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }*/
}
