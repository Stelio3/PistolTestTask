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
        bulletDuration = 3;
        Vector2 direction = TargetFinder.FindNearestTarget(firePoint.position);
        if (direction == Vector2.zero)
            return;

        List<GameObject> _bullets = new List<GameObject>();
        for (int i = 0; i < pelletCount; i++)
        {
            float angle = spreadAngle * (i - pelletCount / 2);
            Vector2 spreadDirection = Quaternion.Euler(0, 0, angle) * direction;
            GameObject pellet = ObjectPooler.Instance.SpawnFromPool("Bullet", firePoint.position, Quaternion.identity);
            pellet.GetComponent<Rigidbody2D>().velocity = spreadDirection * range;
            _bullets.Add(pellet);
        }

        StartCoroutine(DeactivateBulletAfterTime(_bullets, bulletDuration));
    }
    private IEnumerator DeactivateBulletAfterTime(List<GameObject> bullets, float duration)
    {
        yield return new WaitForSeconds(duration);
        foreach (GameObject bullet in bullets)
        {
            ObjectPooler.Instance.ReturnToPool("Bullet", bullet);
        }

    }
}