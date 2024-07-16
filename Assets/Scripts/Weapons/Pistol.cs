using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Pistol : Weapon
{

    public override void Shoot(Vector2 direction)
    {
        Vector3 currentFirePoint = PlayerController.Instance.transform.position + firePoint.position;
        GameObject bullet = ObjectPooler.Instance.SpawnFromPool("Bullet", currentFirePoint, Quaternion.identity);
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
