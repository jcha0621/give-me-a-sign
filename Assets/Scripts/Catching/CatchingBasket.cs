using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchingBasket : MonoBehaviour
{

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.x = Mathf.Clamp(mousePosition.x, -7.5f, 7.5f);
        mousePosition.y = -3.6f;
        transform.position = mousePosition;
    }
}
