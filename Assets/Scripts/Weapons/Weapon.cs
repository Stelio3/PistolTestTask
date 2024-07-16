using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeapon
{
    public int damage;
    public float range;
    public float fireRate;
    protected float nextFireTime;
    protected Transform firePoint;
    public abstract void Shoot(Vector2 direction);

}