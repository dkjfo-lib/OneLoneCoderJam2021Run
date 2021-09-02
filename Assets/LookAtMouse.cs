using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    public Vector3 reverceScale = new Vector3(-1, -1, 1);

    void Update()
    {
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var delta = worldPosition - (Vector2)transform.position;
        transform.right = delta.normalized;
        if (delta.x < 0)
        {
            transform.localScale = reverceScale;
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
