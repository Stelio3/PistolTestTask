using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _maxMoveSpeed = 3f;

    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        MovePlayer();
    }
    private void MovePlayer()
    {
        Vector2 inputDirection = _joystick.GetInputDirection();
        float inputMagnitude = _joystick.GetInputMagnitude();
        Vector2 moveVector = inputDirection * inputMagnitude * _maxMoveSpeed;
        _rb.velocity = moveVector;
    }
}
