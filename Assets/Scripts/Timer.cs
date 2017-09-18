using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timer;
    public string clockTime;
    public Text clockText;

    //private static int winCondition;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Winning();

        if (timer <= 1)
        {
            SceneManager.LoadScene(2);
            Cursor.visible = true;
        }

        if (timer > 0) // if we are greater than Zero
        {
            timer -= Time.deltaTime; // count down... this alone may take us past Zero

            int mins = Mathf.FloorToInt(timer / 60); // FloorToInt, rounds up
            int secs = Mathf.FloorToInt(timer - mins * 60);

            clockTime = string.Format("{0:0}:{1:00}", mins, secs);
            clockText.text = clockTime;
        }

    }

    /*void Winning()
    {
        winCondition = Player.winScore;
    }*/
}