using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class PlayerShooting : MonoBehaviour
{
    public Transform weaponHolder;

    [SerializeField] private Button _shootWeapon;

    private IWeapon _weapon;
    private float weaponHolderDistance = 0.6f;

    private void Start()
    {
        _shootWeapon.onClick.AddListener(() => Shoot());
    }
    private void Update()
    {
        UpdateWeaponOrbit();
    }
    private void Shoot()
    {
        _weapon.Shoot();
    }
    private void UpdateWeaponOrbit()
    {
        if (_weapon == null)
            return;

        Vector2 direction = TargetFinder.FindNearestTarget(weaponHolder.position);
        if (direction != Vector2.zero)
        {
            float angleToDirection = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            weaponHolder.rotation = Quaternion.Euler(0, 0, angleToDirection);
        }
    }
    public void SetWeapon(GameObject weaponPrefab)
    {
        Weapon weapon = weaponPrefab.GetComponent<Weapon>();
        _weapon = weapon;
    }
}