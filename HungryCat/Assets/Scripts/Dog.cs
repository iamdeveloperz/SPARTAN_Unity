using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float x = mousePos.x;
        x = Mathf.Clamp(x, -8.5f, 8.5f);

        transform.position = new Vector3(x, transform.position.y, 0);
    }
}