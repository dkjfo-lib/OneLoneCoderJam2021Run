using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot : MonoBehaviour, ICanHit
{
    public float damage = 1;
    public float speed = 10;
    public Faction FactionToHit = Faction.AlwaysHit;

    public Object CoreObject => transform;
    public bool IsSelfDamageOn => false;
    public bool IsFriendlyDamageOn => false;
    public bool IsEnemy(Faction faction)
    {
        return faction == FactionToHit;
    }

    void Update()
    {
        var movement = transform.right * speed * Time.deltaTime;
        transform.position += movement;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hittable = collision.GetComponent<IHittable>();
        if (hittable == null) return;

        if (this.ShouldHit(hittable))
        {
            hittable.GetHit(new Hit(damage));

            Destroy(gameObject);
        }
    }
}
