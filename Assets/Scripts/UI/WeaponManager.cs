using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    //[SerializeField] private Button _pistolButton;
    //[SerializeField] private Button _shotgunButton;

    public WeaponList_SO weaponList;
    [SerializeField] private PlayerShooting _playerShooting;
    public GameObject buttonPrefab;
    public Transform buttonParent;
    //[SerializeField] private Pistol _pistol;
    //[SerializeField] private Shotgun _shotggun;

    private void Start()
    {
        if (_playerShooting != null)
        {
            GenerateWeaponButtons();
        }
    }
    private void GenerateWeaponButtons()
    {
        //Set first weapon as default
        _playerShooting.SetWeapon(weaponList.weapons[0].weaponType);

        //Instantiate weapon's buttons
        foreach (var weapon in weaponList.weapons)
        {
            GameObject newButton = Instantiate(buttonPrefab, buttonParent);

            WeaponBtn weaponBtn = newButton.GetComponent<WeaponBtn>();
            weaponBtn.SetIconImage(weapon.weaponIcon);

            newButton.GetComponent<Button>().onClick.AddListener(() => _playerShooting.SetWeapon(ChangeWeapon(weapon)));
        }
    }
    private Weapon ChangeWeapon(WeaponsData weaponData)
    {
        return weaponData.weaponType;
    }
}
