using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    private void Start()
    {
        float x = Random.Range(-3.0f, 3.0f);
        float y = Random.Range(3.0f, 5.0f);

        transform.position = new Vector3(x, y, 0);

        float size = Random.Range(0.5f, 1.5f);
        transform.localScale = new Vector3(size, size, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Balloon")
            GameManager.Instance.GameOver();
    }

    private void Update()
    {
        if (transform.position.y < -5f)
            Destroy(gameObject);
    }
}