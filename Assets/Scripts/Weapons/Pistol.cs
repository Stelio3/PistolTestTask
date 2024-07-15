using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Pistol : Weapon
{
    public Transform firePoint;

    public override void Shoot(Vector2 direction)
    {
        GameObject bullet = ObjectPooler.Instance.SpawnFromPool("Bullet", firePoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * range;
        nextFireTime = Time.time + 1f / fireRate;

        //if (Time.time >= nextFireTime)
        //{
        //    GameObject bullet = ObjectPooler.Instance.SpawnFromPool("Bullet", firePoint.position, Quaternion.identity);
        //    bullet.GetComponent<Rigidbody2D>().velocity = direction * range;
        //    nextFireTime = Time.time + 1f / fireRate;
        //}
    }
}
