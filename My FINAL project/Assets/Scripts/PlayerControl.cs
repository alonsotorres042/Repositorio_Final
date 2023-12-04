using JetBrains.Annotations;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    RaycastHit hit;
    private bool CanJump;
    public float RaycastLenght = 0.47f;
    public LayerMask Layer;
    public int MaxExtraJumps = 0;
    private int ExtraAvailableJumps = 0;
    public Transform VisionTarget;
    private Transform _transform;
    private Rigidbody _myRB;
    private float CircularSpeed;
    public float SpeedValue;
    private float _counter;
    public float Thrust;
    public float Width;
    public float Depth;
    // Start is called before the first frame update
    void Start()
    {
        CanJump = true;
        Thrust = 300f;
        Width = 9;
        Depth = 9;
        _counter = 0;
        SpeedValue = 1;
        CircularSpeed = 0;
        _myRB = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _counter += Time.deltaTime * CircularSpeed;
        float x = Mathf.Cos(_counter) * Width;
        float z = Mathf.Sin(_counter) * Depth;

        _transform.position = new Vector3(x, _transform.position.y, z);



    }
    void FixedUpdate()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100, Color.blue);
        _transform.LookAt(VisionTarget);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, RaycastLenght, Layer))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * RaycastLenght, Color.yellow);
            ExtraAvailableJumps = MaxExtraJumps;
            CanJump = true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * RaycastLenght, Color.white);
            if (MaxExtraJumps == 0)
            {
                CanJump = false;
            }
        }
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
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed)
        {   
            if (CanJump == true && ExtraAvailableJumps >= 0)
            {
                _myRB.AddForce(_transform.up * Thrust);
                ExtraAvailableJumps--;
                if (ExtraAvailableJumps == 0)
                {
                    CanJump = false;
                }
            }
        }
    }
    public void OnFire(InputAction.CallbackContext context)
    {
        Debug.Log("Just fired!");
    }
}