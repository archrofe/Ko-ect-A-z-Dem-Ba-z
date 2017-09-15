using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour
{
    [Header("Bools")]
    public bool gameScene;
    public bool showPause;
    public bool pause;
    /* Setting bool/true of false
    public bool fullscreen;
    */

    [Header("References")]
    public GameObject menu;

    void Start()
    {

    }

    public bool TogglePause()
    {
        if (pause)
        {
            if (!showPause)
            {
                Time.timeScale = 1;
                Cursor.visible = false;
                menu.SetActive(false);
                pause = false;
            }
            else
            {
                showPause = false;
                menu.SetActive(true);
            }
            return false;
        }
        else
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pause = true;
            menu.SetActive(true);

            return true;
        }
    }

    void Update()
    {
        if (gameScene)
        {
            // if (Input.GetKeyDown(KeyCode.Escape) && pause == false)
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();
            }
        }
    }

    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void Player()
    {
        TogglePause();
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}