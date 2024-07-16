using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Button _shootWeapon;

    private IWeapon _weapon;

    private void Start()
    {
        _shootWeapon.onClick.AddListener(() => Shoot());
    }
    private void Shoot()
    {
        Vector2 targetDirection = TargetFinder.FindNearestTarget(transform.position);
        if (targetDirection != Vector2.zero)
            _weapon.Shoot(targetDirection);
    }
    public void DoDamage(int damage)
    {
        Debug.Log("Damage received");
    }
    public void SetWeapon(Weapon weapon)
    {
        _weapon = weapon;
    }
}