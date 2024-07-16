using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    public Transform player;

    public RawImage _backgroundImage;
    public float _x = 0.001f;
    public float _y = 0.001f;

    private Vector3 previousPlayerPosition;

    void Update()
    {
        Vector3 deltaMovement = player.position - previousPlayerPosition;

        // Update UV coordinates
        Rect uvRect = _backgroundImage.uvRect;
        uvRect.position += new Vector2(deltaMovement.x * _x, deltaMovement.y * _y);
        _backgroundImage.uvRect = uvRect;

        // Update previous player position
        previousPlayerPosition = player.position;
    }
}