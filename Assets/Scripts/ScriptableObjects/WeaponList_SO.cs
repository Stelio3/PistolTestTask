using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "CreateNewWeaponList", menuName = "ScriptableObjects/WeaponList", order = 1)]
public class WeaponList_SO : ScriptableObject
{
    public WeaponsData[] weapons;
}
[Serializable]
public class WeaponsData
{
    public Sprite weaponIcon;
    public GameObject weaponPrefab;
    public Weapon weaponType;
    [HideInInspector] public WeaponBtn weaponBtn;
}
