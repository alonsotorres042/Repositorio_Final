using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float Speed;
    private Vector3 _velocity;
    public PlayerControl AimPosition;
    void Start()
    {
        _velocity = AimPosition.AimDirection.normalized * - 1;
    }
    void Update()
    {
        transform.position = transform.position + _velocity * Speed;
    }
    public void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
