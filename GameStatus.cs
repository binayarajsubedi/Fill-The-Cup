using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    // configuration parameters
    [SerializeField] int pointsPerCatch;
    [SerializeField] TextMeshProUGUI scoreBoard;
    public int currentScore = 0;

    private void Start()
    {
        PlayerPrefs.GetInt("Gamescores");
        scoreBoard.text = PlayerPrefs.GetInt("Gamescores").ToString();
    }

    public void AddToScore()
    {
        currentScore += pointsPerCatch;
        scoreBoard.text = PlayerPrefs.GetInt("Gamescores").ToString();
    }

    private void Update()
    {
        PlayerPrefs.SetInt("Gamescores", currentScore);
    }
}