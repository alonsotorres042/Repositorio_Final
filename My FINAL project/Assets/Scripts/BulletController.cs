using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float Speed;
    private Vector3 _velocity;
    public GameObject Sight;
    void Start()
    {
        _velocity = transform.position - Sight.transform.position;
    }
    void Update()
    {
        transform.position = transform.position + (_velocity * -1) * Speed;
    }
    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
