using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    public static int remainingTime = 10;
    public TextMeshProUGUI scoreText;
    public GameObject scoreTimePanel;
    public GameObject endGame;
    public TextMeshProUGUI gameOverText;
    public static float timeMoveSpeed = 0.004f;



    void Start()
    {
        StartCoroutine(CountdownTimer());
    }

    void Update()
    {
        scoreText.text = "Score: " + score + " | " + "Time " + remainingTime;
    }

    public static void AddScore(int amount)
    {
        score += amount;
    }

    private IEnumerator CountdownTimer()
    {
        while (remainingTime > 0)
        {
            yield return new WaitForSeconds(1f);
            remainingTime--;
        }
        GameOver();
    }

    private void GameOver()
    {
        Time.timeScale = 0;

        if (score > 12) { gameOverText.text = "You Win\nScore: " + score; }
        else { gameOverText.text = "Game Over\nScore: " + score; }


        endGame.SetActive(true);
        scoreTimePanel.SetActive(false);



    }
}
