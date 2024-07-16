using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class WeaponManager : Singleton<WeaponManager>
{
    public WeaponList_SO weaponList;
    public GameObject buttonPrefab;
    public Transform buttonParent;

    private PlayerShooting _playerShooting;

    public WeaponsData ActiveWeapon { get; private set; }
    private GameObject newWeaponPrefab;

    private void Awake()
    {
        _playerShooting = PlayerController.Instance.GetPlayerShooting();
    }
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
    private GameObject ChangeWeapon(WeaponsData weaponData)
    {
        //Deactive UI
        if (ActiveWeapon != null)
            ActiveWeapon.weaponBtn.DeactivateWeapon();

        //Destroy player weapon
        if (newWeaponPrefab != null)
            Destroy(newWeaponPrefab);

        ActiveWeapon = weaponData;
        weaponData.weaponBtn.ActivateWeapon();
        newWeaponPrefab = Instantiate(weaponData.weaponPrefab, _playerShooting.transform);
        return newWeaponPrefab;
    }
}
