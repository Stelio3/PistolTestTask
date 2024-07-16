using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Pistol : Weapon
{
    public override void Shoot()
    {
        bulletDuration = 5;
        Vector2 direction = TargetFinder.FindNearestTarget(firePoint.position);
        if (direction == Vector2.zero)
            return;

        GameObject bullet = ObjectPooler.Instance.SpawnFromPool("Bullet", firePoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * range;

        StartCoroutine(DeactivateBulletAfterTime(bullet, bulletDuration));
    }
    private IEnumerator DeactivateBulletAfterTime(GameObject bullet, float duration)
    {
        yield return new WaitForSeconds(duration);
        ObjectPooler.Instance.ReturnToPool("Bullet", bullet);
    }
}
