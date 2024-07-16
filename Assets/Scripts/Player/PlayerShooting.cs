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
        _weapon.Shoot();
    }
    public void DoDamage(int damage)
    {
        Debug.Log("Damage received");
    }
    public void SetWeapon(GameObject weaponPrefab)
    {
        Weapon weapon = weaponPrefab.GetComponent<Weapon>();
        _weapon = weapon;
    }
}