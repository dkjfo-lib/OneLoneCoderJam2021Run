using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corpse : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public Sprite deadInAir;
    public Sprite deadOnGround;
    [Space]
    public Rigidbody2D Rigidbody2D;
    public Vector2 deathForce;
    [Space]
    public GroundDetector GroundDetector;

    void Start()
    {
        Rigidbody2D.velocity = new Vector3(deathForce.x * transform.localScale.x, deathForce.y);
    }

    void Update()
    {
        if (GroundDetector.onGround)
            SpriteRenderer.sprite = deadOnGround;
        else
            SpriteRenderer.sprite = deadInAir;
    }
}
