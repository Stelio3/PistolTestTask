using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeapon
{
    public int damage;
    public float range;
    protected float bulletDuration;
    public Transform firePoint;
    public abstract void Shoot();

}