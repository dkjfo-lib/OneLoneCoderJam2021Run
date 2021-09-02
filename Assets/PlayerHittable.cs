using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHittable : MonoBehaviour, IHittable
{
    public float hp = 3;
    public Faction faction = Faction.AlwaysHit;
    public Faction Faction => faction;

    public void GetHit(Hit hit)
    {
        hp -= hit.damage;
        if (hp < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
