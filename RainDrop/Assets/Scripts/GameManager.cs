using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject panel;
    public Text scoreText;
    public Text timeText;

    private void Awake()
    {
        instance = this;
    }

    public GameObject rain;
    private int totalScore;
    private float limit = 10f;

    private void Start()
    {
        InvokeRepeating("MakeRain", 0, 0.5f);
        this.InitGame();
    }

    void InitGame()
    {
        Time.timeScale = 1f;
        totalScore = 0;
        limit = 10.0f;
    }

    private void Update()
    {
        limit -= Time.deltaTime;

        if(limit <= 0)
        {
            limit = 0f;
            panel.SetActive(true);
            Time.timeScale = 0f;
        }
        timeText.text = limit.ToString("N2");
    }

    private void MakeRain()
    {
        Instantiate(rain);
    }

    public void AddScore(int score)
    {
        totalScore += score;
        scoreText.text = totalScore.ToString();
    }

    public void retry()
    {
        SceneManager.LoadScene("MainScene");
    }
}