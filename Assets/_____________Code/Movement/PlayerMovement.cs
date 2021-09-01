using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 100;
    public float speedMult = .97f;
    public float drag = 10;

    void FixedUpdate()
    {
        var input = CreateInput();
    }

    private Vector2 CreateInput()
    {
        var input = Vector2.zero;
        return input;
    }
}
