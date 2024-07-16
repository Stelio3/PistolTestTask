using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeapon
{
    public int damage;
    public float range;
    public Transform firePoint;
    public abstract void Shoot();

}