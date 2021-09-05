using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour, IMovement
{
    public float speed = 700;
    public float speedMultInAir = .98f;
    [Space]
    public float dashTime = 1;
    public float betweenDashTime = 1;
    [Space]
    public float gravity = 0;

    Rigidbody2D rb;
    BotSight bs;

    public Vector2 input;
    public Vector2 CurrentInput => input;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bs = GetComponentInChildren<BotSight>();
        rb.gravityScale = gravity;
        StartCoroutine(KeepDashing());
    }

    IEnumerator KeepDashing()
    {
        while (true)
        {
            input = Vector2.zero;
            yield return new WaitUntil(() => bs.canSee);

            input = CreateInput();
            yield return new WaitForSeconds(dashTime);

            input = Vector2.zero;
            yield return new WaitForSeconds(betweenDashTime);
        }
    }

    void FixedUpdate()
    {
        if (input != Vector2.zero)
        {
            var movement = input * speed * Time.fixedDeltaTime;
            rb.velocity = movement;
        }
        else
        {
            rb.velocity = rb.velocity * speedMultInAir;
        }
    }

    private Vector2 CreateInput()
    {
        input = Vector2.zero;
        if (bs.canSee)
        {
            input = bs.directionToPlayer;
        }
        return input;
    }
}
