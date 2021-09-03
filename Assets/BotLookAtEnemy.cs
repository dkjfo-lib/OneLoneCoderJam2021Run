using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotLookAtEnemy : MonoBehaviour
{
    public Vector3 reverceScale = new Vector3(-1, -1, 1);

    BotSight bs;

    private void Start()
    {
        bs = transform.parent.parent.GetComponentInChildren<BotSight>();
    }

    void Update()
    {
        if (bs.canSee)
        {
            var delta = bs.vectorToPlayer;
            transform.right = delta.normalized;
            if (delta.x < 0)
            {
                transform.localScale = reverceScale;
                if (transform.localEulerAngles.y > 0)
                {
                    transform.localScale = new Vector3(transform.localScale.x, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(transform.localScale.x, -1, 1);
                }
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else
        {
            transform.right = Vector2.right;
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
