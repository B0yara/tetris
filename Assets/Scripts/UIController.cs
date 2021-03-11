using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController: MonoBehaviour
{
    public GameObject gameOver;
    public Text scoreLabel;
    
    public void DisplayScore(int score)
    {
        scoreLabel.text = "Score: \n" + score;
    }
    public void PushGameOver()
    {
        gameOver.SetActive(true);
    }
}