using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject square;
    public GameObject endPanel;
    public Text timeText;
    public Text thisScoreText;
    public Text bestScoreText;
    public Animator anim;

    private float alive = 0f;

    bool isRunning = true;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1f;
        InvokeRepeating("MakeSquare", 0f, 0.5f);
    }

    private void Update()
    {
        if (isRunning)
        {
            alive += Time.deltaTime;
            timeText.text = alive.ToString("N2");
        }
    }

    public void GameOver()
    {
        anim.SetBool("isDie", true);
        isRunning = false;
        Invoke("timeStop", 0.5f);

        thisScoreText.text = alive.ToString("N2");
        bestScoreText.text = PlayerPrefs.GetFloat("bestScore").ToString("N2");
        endPanel.SetActive(true);

        if (PlayerPrefs.HasKey("bestScore") == false)
            PlayerPrefs.SetFloat("bestScore", alive);
        else
        {
            if (PlayerPrefs.GetFloat("bestScore") < alive)
                PlayerPrefs.SetFloat("bestScore", alive);
        }
    }

    private void timeStop()
    {
        Time.timeScale = 0f;
    }

    public void Retry()
    {
        SceneManager.LoadScene("MainScene");
    }

    private void MakeSquare()
    {
        Instantiate(square);
    }
}