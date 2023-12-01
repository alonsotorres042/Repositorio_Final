using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody _myRB;
    private Transform _transform;
    public Vector3 VectorSpeed;
    public float CircularSpeed;
    public float SpeedValue;
    private float _counter;
    public float Width;
    public float Depth;
    // Start is called before the first frame update
    void Start()
    {
        Width = 10;
        Depth = 10;
        _counter = 0;
        SpeedValue = 5;
        CircularSpeed = 0;
        _myRB = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //_myRB.velocity = VectorSpeed;        <------   LIBERAR EN CASO DE QUERER MOVIMIENTO X & Z NORMALES.
        _counter += Time.deltaTime * CircularSpeed;

        float x = Mathf.Cos(_counter) * Width;
        float z = Mathf.Sin(_counter) * Depth;

        _transform.position = new Vector3(x, _transform.position.y, z);
    }
    public void OnMovement(InputAction.CallbackContext context) 
    {
        Vector3 moveInput = context.ReadValue<Vector3>();
        VectorSpeed = moveInput * CircularSpeed;
    }
    public void OnCircularMovement(InputAction.CallbackContext context)
    {
        Vector2 PlayerInput = context.ReadValue<Vector2>();
        if(context.performed)
        {
            CircularSpeed += PlayerInput.x * SpeedValue;
        }
        else
        {
            CircularSpeed = 0;
        }
        Debug.Log(PlayerInput);
    }
}