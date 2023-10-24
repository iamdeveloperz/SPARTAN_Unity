using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject food;
    public GameObject dog;
    public GameObject normalCat;
    public GameObject fatCat;
    public GameObject pirateCat;
    public GameObject retryBtn;

    public Text levelText;
    public GameObject levelFront;

    int level = 0;
    int catCount = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1f;
        InvokeRepeating("MakeFood", 0f, 0.1f);
        InvokeRepeating("MakeCat", 0f, 1f);
    }

    private void MakeFood()
    {
        float x = dog.transform.position.x;
        float y = dog.transform.position.y + 2f;
        Instantiate(food, new Vector3(x, y, 0), Quaternion.identity);
    }

    private void MakeCat()
    {
        Instantiate(normalCat);

        if (level == 1)
        {
            float p = Random.Range(0, 10);
            if (p < 2) Instantiate(normalCat);
        }
        else if (level == 2)
        {
            float p = Random.Range(0, 10);
            if (p < 5) Instantiate(normalCat);
        }
        else if (level == 3)
        {
            float p = Random.Range(0, 10);
            if (p < 6) Instantiate(normalCat);

            Instantiate(fatCat);
        }
        else if(level >= 4)
        {
            float p = Random.Range(0, 10);
            if (p < 6) Instantiate(normalCat);

            Instantiate(pirateCat);
            Instantiate(fatCat);
        }
    }

    public void GameOver()
    {
        retryBtn.SetActive(true);
        Time.timeScale = 0f;
    }

    public void AddCatCount()
    {
        catCount += 1;
        level = catCount / 5;

        levelText.text = level.ToString();
        levelFront.transform.localScale = new Vector3((catCount - level * 5) / 5f, 1f, 1f);
    }
}