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

    public string sceneName;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;

        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();
        // Retrieve the name of this scene.
        sceneName = currentScene.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F11)) // for DEBUGGING purposes!
        {
            timer = 11f;
        }

        if (timer <= 1)
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

        if (timer > 0) // if we are greater than Zero
        {
            timer -= Time.deltaTime; // count down... this alone may take us past Zero

            int mins = Mathf.FloorToInt(timer / 60); // FloorToInt, rounds up
            int secs = Mathf.FloorToInt(timer - mins * 60);

            clockTime = string.Format("{0:0}:{1:00}", mins, secs);
            clockText.text = clockTime;
        }

    }

}