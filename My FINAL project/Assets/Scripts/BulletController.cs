using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float Speed;
    private Vector3 _velocity;
    public PlayerControl Player;
    public Transform ViewTarget;
    void Start()
    {
        _velocity = Player.AimDirection.normalized * - 1;
        transform.LookAt(ViewTarget);
        if(gameObject.name != "TestBullet2")
        {
            Destroy(gameObject, 5);
        }   
    }
    void Update()
    {
        transform.position = transform.position + _velocity * Speed;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
