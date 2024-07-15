using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    private void Awake()
    {
        //gameObject.GetComponent<Rigidbody2D>().velocity = transform.right * _speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //var hero = other.GetComponent<Damageable>();
        //hero?.DoDamage(10);

        //Destroy(gameObject);
    }
}
