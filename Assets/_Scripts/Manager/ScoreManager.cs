using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    [SerializeField] private int remainingTime = 10;
    [SerializeField] private TMP_InputField inputField;
    public TextMeshProUGUI scoreText;
    public GameObject scoreTimePanel;
    public GameObject endGame;
    public TextMeshProUGUI gameOverText;
    public static float timeMoveSpeed = 0.004f;
    public List<Card> cards = new List<Card>();





    void Start()
    {

    }


    public static void AddScore(int amount)
    {
        score += amount;
    }

    public IEnumerator CountdownTimer(int numberMap)
    {


        while (remainingTime > 0)
        {

            scoreText.text = "Score: " + score + " | " + "Time " + remainingTime;
            yield return new WaitForSeconds(1f);
            if (score == numberMap / 2) remainingTime = 0;
            remainingTime--;

        }

        GameOver(numberMap);



    }

    private void GameOver(int numberMap)
    {

        Time.timeScale = 0;

        if (score == numberMap / 2)
        {

            gameOverText.text = "You Win\nScore: " + score ;
            Debug.Log(numberMap);
            

        }
        else { gameOverText.text = "Game Over\nScore: " + score; }


        endGame.SetActive(true);
        scoreTimePanel.SetActive(false);



    }
    public void RunTime(int numberMap)
    {
        StartCoroutine(CountdownTimer(numberMap));
    }
}
