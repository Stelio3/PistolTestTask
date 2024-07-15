using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private Button _pistolButton;
    [SerializeField] private Button _shotgunButton;

    [SerializeField] private PlayerShooting _playerShooting;
    [SerializeField] private Pistol _pistol;
    [SerializeField] private Shotgun _shotggun;

    private void Start()
    {
        if (_playerShooting != null)
        {
            //Set pistol weapon as default
            _playerShooting.SetWeapon(_pistol);

            _pistolButton.onClick.AddListener(() => _playerShooting.SetWeapon(ChangeWeapon(_pistol)));
            _shotgunButton.onClick.AddListener(() => _playerShooting.SetWeapon(ChangeWeapon(_shotggun)));
        }
    }
    private Weapon ChangeWeapon(Weapon weapon)
    {
        return weapon;
    }
}
