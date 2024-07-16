using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponBtn : MonoBehaviour
{
    [SerializeField] private Image iconImage;

    public void SetIconImage(Sprite sprite)
    {
        iconImage.sprite = sprite;
    }
}
