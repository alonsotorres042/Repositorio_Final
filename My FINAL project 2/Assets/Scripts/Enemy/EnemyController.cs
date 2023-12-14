using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float Cadency;
    public GameData GameData;
    public GameObject EnemyBullet;
    public Transform EnemyBulletSpawner;
    private IEnumerator corutineFunction;


    public event Action GetDamage;

    public void Awake()
    {
        GameData.EnemySP = GetComponent<SpriteRenderer>();
        GameData.Enemy = this;
        corutineFunction = ShootPlayer(Cadency);
        GameData.CurrenEnemytLife = GameData.EnemyLife;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(corutineFunction);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + (transform.position - GameData.Player.position).normalized);
        if (Input.GetKeyDown(KeyCode.C))
        {
            StopCoroutine(corutineFunction);
        }
    }
    IEnumerator ShootPlayer(float Cadency)
    {
        while (true)
        {
            Instantiate(EnemyBullet, EnemyBulletSpawner.position, Quaternion.identity);
            yield return new WaitForSeconds(Cadency);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            GetDamage?.Invoke();
        }
    }
}
