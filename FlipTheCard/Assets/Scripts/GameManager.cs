using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text ui_TimeText;
    public GameObject ui_EndText;
    public GameObject card;

    public GameObject firstCard;
    public GameObject secondCard;

    public AudioClip match;
    private AudioSource audioSource;

    private float time;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1f;

        audioSource = GetComponent<AudioSource>();

        int[] rtans = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        rtans = rtans.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();

        for (int i = 0; i < 16; ++i)
        {
            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("Cards").transform;

            float x = (i % 4) * 1.4f;
            float y = (i / 4) * 1.4f;
            newCard.transform.position = new Vector3(x - 2.1f, y - 3.0f, 0);

            string rtanName = "rtan" + rtans[i].ToString();
            newCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(rtanName);
        }
    }

    private void Update()
    {
        time += Time.deltaTime;
        ui_TimeText.text = time.ToString("N2");

        if (time >= 3f)
        {
            ui_EndText.SetActive(true);
            Time.timeScale = 0f;

            time = 30f;
            ui_TimeText.text = time.ToString("N2");
        }
    }

    public void IsMatched()
    {
        string firstCardImage = firstCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite.name;

        if (firstCardImage == secondCardImage)
        {
            audioSource.PlayOneShot(match);

            firstCard.GetComponent<Card>().DestroyCard();
            secondCard.GetComponent<Card>().DestroyCard();

            int cardsLeft = GameObject.Find("Cards").transform.childCount;
            if (cardsLeft == 2)
            {
                ui_EndText.SetActive(true);
                Time.timeScale = 0f;
            }
        }
        else
        {
            firstCard.GetComponent<Card>().CloseCard();
            secondCard.GetComponent<Card>().CloseCard();
        }

        firstCard = null;
        secondCard = null;
    }


    public void RetryGame()
    {
        SceneManager.LoadScene("MainGame");
    }
}
