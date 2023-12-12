using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameData GameData;
    private Vector3 _direction;
    public float Speed;
    void Start()
    {
        _direction = (transform.position - GameData.Sight.position) * -1;
        _direction.Normalize();
        transform.LookAt(GameData.Sight);
        if(gameObject.name != "TestBullet2")
        {
            Destroy(gameObject, 5);
        }   
    }
    void Update()
    {
        transform.position = transform.position + _direction * Speed;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
