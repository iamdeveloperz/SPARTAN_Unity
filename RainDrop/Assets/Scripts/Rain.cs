using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    enum E_RainType
    {
        BIG,
        MID,
        SMALL,
        MINUS
    };

    E_RainType type;
    float size;
    int score;

    private void Start()
    {
        float x = Random.Range(-2.7f, 2.7f);
        float y = Random.Range(3.0f, 5.0f);
        transform.position = new Vector3(x, y, 0);

        type = (E_RainType)Random.Range(0, (int)((E_RainType.MINUS) + 1));
        var renderer = GetComponent<SpriteRenderer>();

        switch(type)
        {
            case E_RainType.BIG:
                size = 1.2f; score = 3;
                renderer.color = new Color(100 / 255f, 100 / 255f, 255 / 255f, 255 / 255f);
                break;
            case E_RainType.MID:
                size = 1.0f; score = 2;
                renderer.color = new Color(130 / 255f, 130 / 255f, 255 / 255f, 255 / 255f);
                break;
            case E_RainType.SMALL:
                size = 0.8f; score = 1;
                renderer.color = new Color(150 / 255f, 150 / 255f, 255 / 255f, 255 / 255f);
                break;
            case E_RainType.MINUS:
                size = 0.8f; score = -5;
                renderer.color = new Color(255 / 255f, 100 / 255f, 100 / 255f, 255 / 255f);
                break;
        }

        transform.localScale = new Vector3(size, size, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Player")
        {
            GameManager.instance.AddScore(score);
            Destroy(gameObject);
        }
    }
}