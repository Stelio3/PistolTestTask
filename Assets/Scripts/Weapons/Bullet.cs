using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        ITarget enemy = other.GetComponent<ITarget>();
        if(enemy != null)
        {
            enemy.TakeDamage(10);
            ObjectPooler.Instance.ReturnToPool("Bullet", gameObject);
        }
    }
}
