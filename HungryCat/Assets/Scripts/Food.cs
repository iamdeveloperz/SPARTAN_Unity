using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private void Update()
    {
        transform.position += new Vector3(0f, 0.5f, 0f);
        if (transform.position.y > 26f)
            Destroy(gameObject);
    }
}