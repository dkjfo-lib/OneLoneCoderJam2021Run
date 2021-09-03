using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHittable : MonoBehaviour, IHittable
{
    public float hp = 3;
    public Faction faction = Faction.AlwaysHit;
    public Faction Faction => faction;
    [Space]
    public bool isHead = false;
    public Corpse Headfull;
    public Corpse Headless;

    public void GetHit(Hit hit)
    {
        hp -= hit.damage;
        if (hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        var corpse = Instantiate(isHead ? Headless : Headfull, transform.position, Quaternion.identity);
        corpse.transform.localScale = new Vector3(transform.localScale.x, 1, 1);
        Destroy(transform.parent.parent.gameObject);
    }
}
