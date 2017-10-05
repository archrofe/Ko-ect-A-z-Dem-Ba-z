using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossWinLoseScores : MonoBehaviour
{
    public Text scoreText;
    private static int carryoverScore; // using this below to carry-over score (count) from Player script

	// Use this for initialization
	void Start ()
    {
        SetScoreText();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void SetScoreText()
    {
        carryoverScore = Player.count;
        scoreText.text = "Your Score: " + carryoverScore.ToString();
    }

}
