using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Shotgun : Weapon
{
    public int pelletCount = 5;
    public float spreadAngle = 15f;

    public override void Shoot()
    {
        Vector2 direction = TargetFinder.FindNearestTarget(firePoint.position);
        if (direction == Vector2.zero)
            return;

        for (int i = 0; i < pelletCount; i++)
        {
            float angle = spreadAngle * (i - pelletCount / 2);
            Vector2 spreadDirection = Quaternion.Euler(0, 0, angle) * direction;
            GameObject pellet = ObjectPooler.Instance.SpawnFromPool("Bullet", firePoint.position, Quaternion.identity);
            pellet.GetComponent<Rigidbody2D>().velocity = spreadDirection * range;
        }
    }
}