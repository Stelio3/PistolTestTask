using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Shotgun : Weapon
{
    public Transform firePoint;
    public int pelletCount = 5;
    public float spreadAngle = 15f;

    public override void Shoot(Vector2 direction)
    {
        for (int i = 0; i < pelletCount; i++)
        {
            float angle = spreadAngle * (i - pelletCount / 2);
            Vector2 spreadDirection = Quaternion.Euler(0, 0, angle) * direction;
            Vector3 currentFirePoint = PlayerController.Instance.transform.position + firePoint.position;
            GameObject pellet = ObjectPooler.Instance.SpawnFromPool("Bullet", currentFirePoint, Quaternion.identity);
            pellet.GetComponent<Rigidbody2D>().velocity = spreadDirection * range;
        }
        //if (Time.time >= nextFireTime)
        //{
        //    for (int i = 0; i < pelletCount; i++)
        //    {
        //        float angle = spreadAngle * (i - pelletCount / 2);
        //        Vector2 spreadDirection = Quaternion.Euler(0, 0, angle) * direction;
        //        GameObject pellet = ObjectPooler.Instance.SpawnFromPool("Bullet", firePoint.position, Quaternion.identity);
        //        pellet.GetComponent<Rigidbody2D>().velocity = spreadDirection * range;
        //    }
        //    nextFireTime = Time.time + 1f / fireRate;
        //}
    }
}