using JetBrains.Annotations;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    float x;
    float z;
    public RaycastHit hit;
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


    private Ray MyRay;
    private bool _canShot;
    private Vector3 MouseOnWorld;
    private Vector3 _aimDirection;
    public Vector3 AimDirection{get{return _aimDirection;}private set{}} 
    public GameObject Bullet;
    public GameObject GraphicMouseOnWorld;
    public Transform ProjectileSpawner;


    public Vector3 MousePosit3D;
    public Vector3 RayHit;
    // Start is called before the first frame update
    void Start()
    {
        CanJump = true;
        Thrust = 300f;
        _counter = 0;
        CircularSpeed = 0;
        _myRB = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _counter += Time.deltaTime * CircularSpeed;
        x = Mathf.Cos(_counter) * Width;
        z = Mathf.Sin(_counter) * Depth;

        _transform.position = new Vector3(x, _transform.position.y, z);
        _transform.LookAt(VisionTarget);
    }
    void FixedUpdate()
    {
        _aimDirection = transform.position - GraphicMouseOnWorld.transform.position;
        if(Physics.Raycast(MyRay, out hit))
        {
            Debug.DrawRay(transform.position, _aimDirection * - 1, Color.red);
            GraphicMouseOnWorld.transform.position = MouseOnWorld;
            MouseOnWorld = hit.point;
        }
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
    public void MousePos(InputAction.CallbackContext context)
    {
        Vector2 MousePos = context.ReadValue<Vector2>();
        MyRay = Camera.main.ScreenPointToRay(MousePos);
    }
    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Instantiate(Bullet, ProjectileSpawner.position, Quaternion.identity);
        }
    }
}