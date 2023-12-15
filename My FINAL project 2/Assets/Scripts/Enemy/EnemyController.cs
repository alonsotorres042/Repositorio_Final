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
    public Color HurtColor;

    public event Action GetDamage;
    public SpriteRenderer _spriteRenderer;

    public void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StopCoroutine(corutineFunction);
        }
    }
    IEnumerator ShootPlayer(float Cadency)
    {
        while (true)
        {
            yield return new WaitForSeconds(Cadency);
            Instantiate(EnemyBullet, EnemyBulletSpawner.position, Quaternion.identity);
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
