using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float movementSpeed = 5;
    public float acceleration = 50f;
    public float deceleration = .1f;
    public Text countText;
    public GameObject player;
    public GameObject superPlayer;
    //public int superDelay = 3;

    private Rigidbody2D rigid;
    private int count;

    public float superCooldown = 3f;


    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        count = 0;
        SetCountText();

    }

    // Update is called once per frame
    void Update()
    {
        #region Player Movement
        // If user presses D
        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            // Move right
            rigid.AddForce(transform.right * acceleration);
        }
        //If user presses A
        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            // Move left
            rigid.AddForce(-transform.right * acceleration);
        }

        //Deceleration
        rigid.velocity += -rigid.velocity * deceleration;
        #endregion

        Shortcuts();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SuperMoveOn();
            Invoke("SuperMoveOff", superCooldown);
        }

    }
    

    #region Triggers and Scoring
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("AverageCandy"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

        if (other.gameObject.CompareTag("FastCandy"))
        {
            other.gameObject.SetActive(false);
            count = count + 5;
            SetCountText();
        }

        if (other.gameObject.CompareTag("BigCandy"))
        {
            other.gameObject.SetActive(false);
            count = count + 10;
            SetCountText();
        }

        if (other.gameObject.CompareTag("GhostCandy"))
        {
            count = count - 100;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
    }
    #endregion

    #region Shortcuts
    void Shortcuts()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.F1))
        {
            SceneManager.LoadScene(0);
        }
    }
    #endregion

    #region SuperMove!
    void SuperMoveOn()
    {
        superPlayer.SetActive(true);
        player.SetActive(false);
    }


    void SuperMoveOff()
    {

        superPlayer.SetActive(false);
        player.SetActive(true);
    }
    

    #endregion

}
