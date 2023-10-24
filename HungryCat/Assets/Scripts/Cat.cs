using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    private float full = 5.0f;
    private float energy = 0f;
    private bool isFull = false;

    public int type;

    private Transform frontBar;
    private Transform hungryCat;
    private Transform fullCat;

    private void Start()
    {
        float x = Random.Range(-8.5f, 8.5f);
        float y = 30f;
        transform.position = new Vector3(x, y, 0);

        if (type == 1)
            full = 10f;

        frontBar = gameObject.transform.Find("Hungry/Canvas/FrontBar");
        hungryCat = gameObject.transform.Find("Hungry");
        fullCat = gameObject.transform.Find("Full");
    }

    private void Update()
    {
        if (energy < full)
        {
            if (type == 0)
                transform.position += new Vector3(0.0f, -0.05f, 0.0f);
            else if (type == 1)
                transform.position += new Vector3(0.0f, -0.03f, 0.0f);
            else if (type == 2)
                transform.position += new Vector3(0.0f, -0.1f, 0.0f);

            if (transform.position.y < -16.0f)
            {
                GameManager.Instance.GameOver();
            }
        }
        else
        {
            if (transform.position.x > 0)
            {
                transform.position += new Vector3(0.05f, 0.0f, 0.0f);
            }
            else
            {
                transform.position += new Vector3(-0.05f, 0.0f, 0.0f);
            }
            Destroy(gameObject, 3.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "food")
        {
            if (energy < full)
            {
                energy += 1f;
                Destroy(collision.gameObject);
                frontBar.localScale = new Vector3(energy / full, 1f, 1f);
            }
            else
            {
                if (isFull == false)
                {
                    GameManager.Instance.AddCatCount();
                    hungryCat.gameObject.SetActive(false);
                    fullCat.gameObject.SetActive(true);

                    isFull = true;
                }
            }
        }
    }
}