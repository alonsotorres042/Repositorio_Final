using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameData GameData;
    private RaycastHit hit;
    public float RaycastLenght;
    public LayerMask Layer;
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
    void Update()
    {
        transform.position = transform.position + _direction * Speed;
    }
    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, _direction, out hit, RaycastLenght, Layer))
        {
            if (hit.collider.name == "Enemy" || hit.collider.GetComponent<EnemyPart>() == true)
            {
                GameData.Score = GameData.Score + 100;
                GameData.audioManager.PlayerHurt();
                GameData.CurrenEnemyLife = GameData.CurrenEnemyLife - BulletDamage;
                hit.collider.GetComponent<SpriteRenderer>().color = GameData.Enemy.HurtColor;
            }
            Destroy(gameObject);
            Debug.DrawRay(transform.position, _direction * RaycastLenght, Color.cyan);
        }
        else
        {
            Debug.DrawRay(transform.position, _direction * RaycastLenght, Color.black);
        }
    }
}