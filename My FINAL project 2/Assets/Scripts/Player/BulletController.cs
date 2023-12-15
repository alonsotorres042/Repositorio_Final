using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameData GameData;
    private Vector3 _direction;
    public float Speed;
    public int BulletDamage;
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
    private void OnEnable()
    {
        GameData.Enemy.GetDamage += GetBulletDamage;
    }
    private void OnDisable()
    {
        GameData.Enemy.GetDamage -= GetBulletDamage;
    }
    void Update()
    {
        transform.position = transform.position + _direction * Speed;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "TestPlayer2D")
        {
            other.GetComponent<SpriteRenderer>().color = GameData.Enemy.HurtColor;
            Destroy(gameObject);
        }
    }
    public void GetBulletDamage()
    {
        //SetLife
        GameData.CurrenEnemytLife -= BulletDamage;

    }
}