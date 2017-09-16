using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed = 5;
    public float acceleration = 500f;
    public float deceleration = 1f;
    private Rigidbody2D rigid;

    [Header("Scoring")]
    public Text countText;
    public int count;
    public int bluePoints = 50;
    public int redPoints = 100;
    public int ghostPoints = 1000;
    public int bigHolyPoints = 100;
    public int littleHolyPoints = 100;
    public int bigEvilPoints = 1000;
    public int littleEvilPoints = 100;

    [Header("Super Move")]
    public GameObject player;
    public GameObject superPlayer;
    public float superCooldown = 10f;
    private bool isSuperOn;
    public int superMoveCost = 1000;

    [Header("Spawners")]
    public GameObject littleHolySpawner;
    public GameObject littleEvilSpawner;
    public GameObject blueSpawner;
    public GameObject redSpawner;
    public GameObject ghostSpawner;
    public GameObject gravSpawner;
    public GameObject windSpawner;
    public GameObject holySpawner;
    public GameObject evilSpawner;
    public GameObject hardGhostSpawner;
    public GameObject hardEvilSpawner;
    private bool wave1Done = false; // starts with Blue Candy, adds Red Candy on True
    private bool wave2Done = false; // adds Red Candy
    private bool wave3Done = false; // adds Ghost & Grav Candy
    private bool wave4Done = false; // adds Holy Candy
    private bool wave5Done = false; // adds Evil Candy
    private bool wave6Done = false; // starts Hard Wave on True

    [Header("Waves")]
    public int wave2Score = 1000; // Score to start Wave 2
    public int wave3Score = 3000; // to start Wave 3
    public int wave4Score = 5000; // to start Wave 4
    public int wave5Score = 7000; // to start Wave 5
    public int wave6Score = 9000; // to start Wave 6
    public int bossFightScore = 13000; // to start Boss Fight

    [Header("Boss")]
    public GameObject theBoss;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        count = 0;
        SetCountText();

        isSuperOn = false;

        Cursor.visible = false;
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

        if (Input.GetKeyDown(KeyCode.Space) && (isSuperOn == false) && (count >= superMoveCost))
        {
            SuperMoveOn();
        }

        Waves();
    }

    #region Triggers and Scoring
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (isSuperOn == false)
        {
            
            if (other.gameObject.CompareTag("Holy Candy"))
            {
                other.gameObject.SetActive(false);
                count = count + bigHolyPoints;
                SetCountText();
                littleHolySpawner.SetActive(true);
            }

            if (other.gameObject.CompareTag("Little Holy Candy"))
            {
                other.gameObject.SetActive(false);
                count = count + littleHolyPoints;
                SetCountText();
            }

            if (other.gameObject.CompareTag("Little Evil Candy"))
            {
                other.gameObject.SetActive(false);
                count = count - littleEvilPoints;
                SetCountText();
            }

            if (other.gameObject.CompareTag("Evil Candy"))
            {
                other.gameObject.SetActive(false);
                count = count - bigEvilPoints;
                SetCountText();
                littleEvilSpawner.SetActive(true);
            }

            if (other.gameObject.CompareTag("AverageCandy"))
            {
                other.gameObject.SetActive(false);
                count = count + 1;
                SetCountText();
            }

            if (other.gameObject.CompareTag("FastCandy"))
            {
                other.gameObject.SetActive(false);
                count = count + redPoints;
                SetCountText();
            }

            if (other.gameObject.CompareTag("BigCandy"))
            {
                other.gameObject.SetActive(false);
                count = count + bluePoints;
                SetCountText();
            }

            if (other.gameObject.CompareTag("GhostCandy"))
            {
                other.gameObject.SetActive(false);
                count = count - ghostPoints;
                SetCountText();
            }
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
        if (Input.GetKey(KeyCode.F12))
        {
            count = count + 1000; // for Debugging purposes, to be removed from final build
            SetCountText();
        }
    }
    #endregion

    #region SuperMove!
    void SuperMoveOn()
    {
        isSuperOn = true;
        count = count - superMoveCost;
        SetCountText();
        superPlayer.SetActive(true);
        player.SetActive(false);
        Invoke("SuperMoveOff", superCooldown);
    }

    void SuperMoveOff()
    {
        superPlayer.SetActive(false);
        player.SetActive(true);
        isSuperOn = false;
    }
    #endregion

    #region Waves
    void Waves()
    {
        // to start Wave 2
        if (wave1Done == false) // Wave 1 in process
        {
            if (count >= wave2Score) // Score >= Wave 2 start Score?
            {
                redSpawner.SetActive(true); // Activate Red Spawner
                wave1Done = true; // Flag Wave 1 as completed
            }
        }

        // to start Wave 3
        if ((wave1Done == true) && (wave2Done == false)) // Wave 1 done, but in Wave 2
        {
            if (count >= wave3Score)
            {
                ghostSpawner.SetActive(true);
                wave2Done = true; // Wave 2 done
            }
        }

        // to start Wave 4
        if ((wave2Done == true) && (wave3Done == false)) // Wave 2 done, but in Wave 3
        {
            if (count >= wave4Score)
            {
                holySpawner.SetActive(true);
                windSpawner.SetActive(true);
                wave3Done = true; // Wave 3 done
            }
        }

        // to start Wave 5
        if ((wave3Done == true)) // Wave 3 done
        {
            if (wave4Done == false) // but in Wave 4
            {

                if (count >= wave5Score)
                {
                    evilSpawner.SetActive(true);
                    gravSpawner.SetActive(true);
                    wave4Done = true; // Wave 4 done
                }
            }
        }

        // to start Wave 6 (Hard Wave)
        if (wave4Done == true) // Wave 4 done
        {
            if (wave5Done == false) // but in Wave 5
            {
                if (count >= wave6Score)
                {
                    ghostSpawner.SetActive(false);
                    evilSpawner.SetActive(false);
                    hardGhostSpawner.SetActive(true);
                    hardEvilSpawner.SetActive(true);
                    wave5Done = true; // Wave 5 done, starting Wave 6 (Hard Wave) now
                }
            }
        }

        // to start Boss Fight
        if (wave5Done == true) // Wave 5 done
        {
            if (wave6Done == false) // but in Wave 6 (Hard Wave)
            {
                if (count >= bossFightScore)
                {
                    blueSpawner.SetActive(false);
                    redSpawner.SetActive(false);
                    holySpawner.SetActive(false);
                    hardGhostSpawner.SetActive(false);
                    hardEvilSpawner.SetActive(false);
                    //theBoss.SetActive(true);
                    Debug.Log("Boss Fight!");
                }
            }
        }
    }
    #endregion
}
