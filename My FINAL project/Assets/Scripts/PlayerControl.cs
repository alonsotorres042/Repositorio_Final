using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody _myRB;
    public Vector3 Speed; 
    // Start is called before the first frame update
    void Start()
    {
        _myRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _myRB.velocity = Speed;
    }
    public void OnMovement(InputAction.CallbackContext context) 
    {
        Vector3 moveInput = context.ReadValue<Vector3>();
        Speed = moveInput * 2;
        Debug.Log(moveInput);
    }
}