using JetBrains.Annotations;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [Header ("Movement Settings")]
    public RaycastHit hit;
    private bool CanJump;
    private float RaycastLenght = 0.68f;
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


    [Header("Shooting Settings")]
    public GameData GameData;
    private Ray MyRay;
    private bool _canShot;
    private Vector3 MouseOnWorld;
    private Vector3 _aimDirection;
    public Vector3 AimDirection{get{return _aimDirection;}private set{}} 
    public GameObject Bullet;
    public GameObject GraphicMouseOnWorld;
    public Transform ProjectileSpawner;

    public bool _canShoot;
    private bool _isShooting;
    public int MaxAmmo;
    [SerializeField] private int AvailableAmmo;
    private float BurstCADENCY;
    private float BurstTIME;

    // Start is called before the first frame update
    void Start()
    {
        BurstTIME = 0.35f;
        BurstCADENCY = 0.11f;
        _canShoot = true;
        _isShooting = false;
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
        float x = Mathf.Cos(_counter) * Width;
        float z = Mathf.Sin(_counter) * Depth;

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
        GameData.Player = transform;
        GameData.Sight = GraphicMouseOnWorld.transform;
    }
    IEnumerator BurstShots()
    {
        _canShoot = false;
        _isShooting = true;

        while (_isShooting == true)
        {
            for (int i = 0; i < 3; ++i)
            {
                Instantiate(Bullet, ProjectileSpawner.position, Quaternion.identity);
                yield return new WaitForSeconds(BurstCADENCY);
            }
            yield return new WaitForSeconds(BurstTIME);
        }
        _canShoot = true;
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
                _myRB.AddForce(_transform.up * Thrust * 1.5f); 
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
        if (context.performed && _canShoot == true && _isShooting == false)
        {
            StartCoroutine(BurstShots());
        }
        else if(context.canceled)
        {
            _isShooting = false;
        }
    }
}