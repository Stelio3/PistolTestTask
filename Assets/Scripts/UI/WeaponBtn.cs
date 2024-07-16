using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponBtn : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private Color _activeColor;
    [SerializeField] private Color _inactiveColor;

    private Image _buttonImage;

    private void Awake()
    {
        _buttonImage = GetComponent<Image>();
    }
    public void SetIconImage(Sprite sprite)
    {
        iconImage.sprite = sprite;
    }
    public void ActivateWeapon()
    {
        _buttonImage.color = _activeColor;
    }
    public void DeactivateWeapon()
    {
        _buttonImage.color = _inactiveColor;
    }
}
