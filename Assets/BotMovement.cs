using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMovement : MonoBehaviour, IMovement
{
    public Vector2 perfDistance = new Vector2(3, 4);
    public float jumpDist = 4f;
    [Space]
    public float speed = 200;
    public float speedMult = .7f;
    public float speedMultInAir = .98f;
    [Space]
    public float jumpForce = 200;
    public float jumpVelCut = 2;
    public float gravity = 3;

    Rigidbody2D rb;
    GroundDetector gd;
    BotSight bs;

    Vector2 input;
    public Vector2 CurrentInput => input;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gd = GetComponentInChildren<GroundDetector>();
        bs = GetComponentInChildren<BotSight>();
        rb.gravityScale = gravity;
    }

    void FixedUpdate()
    {
        var input = CreateInput();

        if (gd.onGround)
        {
            // move x
            if (input.x != 0)
            {
                if (gd.onGround)
                {
                    var movementX = input.x * speed * Time.fixedDeltaTime;
                    rb.velocity = new Vector2(movementX, rb.velocity.y);
                }
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x * speedMult, rb.velocity.y);
            }
            // move y
            if (input.y != 0)
            {
                var movementY = input.y * jumpForce;
                rb.velocity = new Vector2(rb.velocity.x, movementY);
            }
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x * speedMultInAir, rb.velocity.y);
        }
    }

    private Vector2 CreateInput()
    {
        input = Vector2.zero;
        if (bs.canSee)
        {
            input.x  = bs.vectorToPlayer.x > 0 ? 1 : -1;
            if (bs.distanceToPlayer < perfDistance.x)
            {
                input.x *= -1;
            }
            else if (bs.distanceToPlayer > perfDistance.y)
            {

            }
            else
            {
                input.x = 0;
            }
            input.y  = bs.vectorToPlayer.y > jumpDist ? 1 : 0;
        }
        return input;
    }
}
