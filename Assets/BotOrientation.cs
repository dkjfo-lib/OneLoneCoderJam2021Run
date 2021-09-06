using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotOrientation : MonoBehaviour
{
    BotSight bs;

    private void Start()
    {
        bs = GetComponentInChildren<BotSight>();
    }

    void Update()
    {
        if (!bs.canSee) return;

        var delta = bs.vectorToPlayer;
        if (delta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
