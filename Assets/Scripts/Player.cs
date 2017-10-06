using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Sound")]
    public AudioSource collect;
    public AudioSource collect1;
    public AudioSource collect2;
    public AudioSource collect3;
    public AudioSource collect4;
    public AudioSource collect5;
    public AudioSource collect6;

    private int random;

    [Header("Movement")]
    public float movementSpeed = 5;
    public float acceleration = 500f;
    public float deceleration = 1f;
    private Rigidbody2D rigid;

    [Header("Scoring")]
    public Text countText;
    public static int count;
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

    [Header("Waves")]
    public int wave2Score = 1000; // Score to start Wave 2
    public GameObject wave2Gobj;
    public Text wave2Text;

    public int wave3Score = 3000; // to start Wave 3
    public GameObject wave3Gobgj;
    public Text wave3Text;

    public int wave4Score = 5000; // to start Wave 4
    public GameObject wave4GobjBigHoly;
    public GameObject wave4GobjSmallHoly;
    public Text wave4TextBigHoly;
    public Text wave4TextSmallHoly;

    public int wave5Score = 7000; // to start Wave 5
    public GameObject wave5GobjBigEvil;
    public GameObject wave5GobjSmallEvil;
    public Text wave5TextBigEvil;
    public Text wave5TextSmallEvil;

    public int wave6Score = 9000; // to start Wave 6
    public int winScore = 10000;

    [Header("Boss")]
    public GameObject theBoss;

    public string sceneName;

    // Use this for initialization
    void Start()
    {
        collect.enabled = false;
        collect1.enabled = false;
        collect2.enabled = false;
        collect3.enabled = false;
        collect4.enabled = false;
        collect5.enabled = false;
        collect6.enabled = false;

        rigid = GetComponent<Rigidbody2D>();

        count = 0;
        SetCountText();

        isSuperOn = false;

        Cursor.visible = false;

        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();
        // Retrieve the name of this scene.
        sceneName = currentScene.name;

    }

    // Update is called once per frame
    void Update()
    {
        random = Random.Range(1, 8);

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

    #region IEnumerators
    IEnumerator Collect()
    {
        collect.enabled = true;

        yield return new WaitForSeconds(.1f);

        collect.enabled = false;
    }

    IEnumerator Collect1()
    {
        collect1.enabled = true;

        yield return new WaitForSeconds(.1f);

        collect1.enabled = false;
    }

    IEnumerator Collect2()
    {
        collect2.enabled = true;

        yield return new WaitForSeconds(.1f);


        collect2.enabled = false;
    }

    IEnumerator Collect3()
    {
        collect3.enabled = true;

        yield return new WaitForSeconds(.1f);

        collect3.enabled = false;
    }

    IEnumerator Collect4()
    {
        collect4.enabled = true;

        yield return new WaitForSeconds(.1f);

        collect4.enabled = false;
    }

    IEnumerator Collect5()
    {
        collect5.enabled = true;

        yield return new WaitForSeconds(.1f);

        collect5.enabled = false;
    }

    IEnumerator Collect6()
    {
        collect6.enabled = true;

        yield return new WaitForSeconds(.1f);

        collect6.enabled = false;
    }

    IEnumerator Holy()
    {
        littleHolySpawner.SetActive(true);

        yield return new WaitForSeconds(5);

        littleHolySpawner.SetActive(false);
    }
    #endregion

    #region Triggers, Scoring, and CoRoutines
    private void OnCollisionEnter2D(Collision2D other)
    {

        if(random == 1)
        {
            StartCoroutine(Collect());
        }

        if (random == 2)
        {
            StartCoroutine(Collect1());
        }
        if (random == 3)
        {
            StartCoroutine(Collect2());
        }
        if (random == 4)
        {
            StartCoroutine(Collect3());
        }
        if (random == 5)
        {
            StartCoroutine(Collect4());
        }
        if (random == 6)
        {
            StartCoroutine(Collect5());
        }
        if (random == 7)
        {
            StartCoroutine(Collect6());
        }

        if (isSuperOn == false)
        {
            
            if (other.gameObject.CompareTag("Holy Candy"))
            {
                other.gameObject.SetActive(false);
                count = count + bigHolyPoints;
                SetCountText();

                StartCoroutine(Holy());
                wave4GobjSmallHoly.SetActive(true);
                wave4TextSmallHoly.gameObject.SetActive(true);

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

                wave5GobjSmallEvil.SetActive(true);
                wave5TextSmallEvil.gameObject.SetActive(true);
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

            if (other.gameObject.CompareTag("Boss Candy"))
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

    #region Shortcuts for Debugging
    void Shortcuts()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            count = count + 3000; // for Debugging purposes, to be removed from final build
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
        if (count < 0)
        {
            Cursor.visible = true;

            if (sceneName == "Drop Ball Game")
            {
                SceneManager.LoadScene(2);
            }
            else
            {
                SceneManager.LoadScene(13);
            }
            
        }

        if (count >= winScore)
        {
            Cursor.visible = true;

            if (sceneName == "Drop Ball Game")
            {
                SceneManager.LoadScene(11);
            }
            else
            {
                SceneManager.LoadScene(12);
            }

        }

        // to start Wave 2
        if (wave1Done == false) // Wave 1 in process
        {
            if (count >= wave2Score) // Score >= Wave 2 start Score?
            {
                wave2Gobj.SetActive(true);
                wave2Text.gameObject.SetActive(true);

                redSpawner.SetActive(true); // Activate Red Spawner
                wave1Done = true; // Flag Wave 1 as completed
            }
        }

        // to start Wave 3
        if ((wave1Done == true) && (wave2Done == false)) // Wave 1 done, but in Wave 2
        {
            if (count >= wave3Score)
            {
                wave3Gobgj.SetActive(true);
                wave3Text.gameObject.SetActive(true);

                ghostSpawner.SetActive(true);
                wave2Done = true; // Wave 2 done
            }
        }

        // to start Wave 4
        if ((wave2Done == true) && (wave3Done == false)) // Wave 2 done, but in Wave 3
        {
            if (count >= wave4Score)
            {
                wave4GobjBigHoly.SetActive(true);
                
                wave4TextBigHoly.gameObject.SetActive(true);
                

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
                    wave5GobjBigEvil.SetActive(true);
                    
                    wave5TextBigEvil.gameObject.SetActive(true);
                    

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
    }
    #endregion

}
