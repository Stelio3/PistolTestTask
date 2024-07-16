using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    public WeaponList_SO weaponList;
    public GameObject buttonPrefab;
    public Transform buttonParent;

    [SerializeField] private PlayerShooting _playerShooting;

    private WeaponsData _activeWeapon;
    private GameObject newWeaponPrefab;

    private void Start()
    {
        if (_playerShooting != null)
        {
            GenerateWeaponButtons();
        }
    }
    private void GenerateWeaponButtons()
    {
        //Instantiate weapon's buttons
        foreach (WeaponsData weapon in weaponList.weapons)
        {
            GameObject newButton = Instantiate(buttonPrefab, buttonParent);

            weapon.weaponBtn = newButton.GetComponent<WeaponBtn>();

            weapon.weaponBtn.SetIconImage(weapon.weaponIcon);
            weapon.weaponBtn.GetComponent<Button>().onClick.AddListener(() => _playerShooting.SetWeapon(ChangeWeapon(weapon)));
        }

        //Set first weapon as default
        _playerShooting.SetWeapon(ChangeWeapon(weaponList.weapons[0]));
    }
    private Weapon ChangeWeapon(WeaponsData weaponData)
    {
        //Deactive UI
        if (_activeWeapon != null)
            _activeWeapon.weaponBtn.DeactivateWeapon();

        //Destroy player weapon
        if (newWeaponPrefab != null)
            Destroy(newWeaponPrefab);

        _activeWeapon = weaponData;
        weaponData.weaponBtn.ActivateWeapon();
        newWeaponPrefab = Instantiate(weaponData.weaponPrefab, _playerShooting.transform);
        return weaponData.weaponType;
    }
}
