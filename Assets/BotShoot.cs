using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotShoot : MonoBehaviour
{
    public GunShot projectile;
    public float primariShootsPerSecond = 4;
    bool canShootPrimary = true;
    [Space]
    public SpriteRenderer gunpoint;

    BotMovement Movement;
    BotSight bs;

    private void Start()
    {
        Movement = transform.parent.parent.GetComponent<BotMovement>();
        bs = transform.parent.parent.GetComponentInChildren<BotSight>();
    }

    void Update()
    {
        if (canShootPrimary &&
            bs.canSee &&
            Movement.perfDistance.x < bs.distanceToPlayer &&
            Movement.perfDistance.y > bs.distanceToPlayer)
        {
            StartCoroutine(ShootPrimary());
        }
    }

    private IEnumerator ShootPrimary()
    {
        canShootPrimary = false;
        var newShot = Instantiate(projectile, gunpoint.transform.position, transform.rotation);
        newShot.FactionToHit = Faction.PlayerTeam;

        gunpoint.color = Color.white;
        yield return new WaitForSeconds(Mathf.Min(1 / primariShootsPerSecond, .05f));
        gunpoint.color = new Color(0, 0, 0, 0);

        yield return new WaitForSeconds(1 / primariShootsPerSecond);
        canShootPrimary = true;
    }
}
