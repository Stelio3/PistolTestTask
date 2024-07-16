using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    private PlayerMovement _movement;
    private PlayerShooting _shooting;

    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
        _shooting = GetComponent<PlayerShooting>();
    }

    public PlayerShooting GetPlayerShooting() { return _shooting; }
    public PlayerMovement GetPlayerMovement() { return _movement; }
}
