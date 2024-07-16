using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    public RawImage _backgroundImage;
    public float _x = 0.01f;
    public float _y = 0.01f;

    private Vector3 previousPlayerPosition;

    void Update()
    {
        Vector3 playerPosition = PlayerController.Instance.transform.position;
        Vector3 deltaMovement = playerPosition - previousPlayerPosition;

        // Update UV coordinates
        Rect uvRect = _backgroundImage.uvRect;
        uvRect.position += new Vector2(deltaMovement.x * _x, deltaMovement.y * _y);
        _backgroundImage.uvRect = uvRect;

        // Update previous player position
        previousPlayerPosition = playerPosition;
    }
}