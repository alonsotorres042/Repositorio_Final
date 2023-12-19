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

    public SpriteRenderer _spriteRenderer;

    public void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        GameData.Enemy = this;
        corutineFunction = ShootPlayer(Cadency);
        GameData.CurrenEnemyLife = GameData.EnemyLife;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(corutineFunction);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + (transform.position - GameData.Player.transform.position).normalized);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StopCoroutine(corutineFunction);
        }
    }
    IEnumerator ShootPlayer(float Cadency)
    {
        while (true)
        {
            if (GameData.CurrenEnemyLife < (GameData.EnemyLife / 3) * 2 && GameData.CurrenEnemyLife > GameData.EnemyLife / 3)
            {
                yield return new WaitForSeconds(Cadency/2);
            }else if(GameData.CurrenEnemyLife < GameData.EnemyLife / 3)
            {
                yield return new WaitForSeconds(Cadency / 3);
            }else
            {
                yield return new WaitForSeconds(Cadency);
            }
            Instantiate(EnemyBullet, EnemyBulletSpawner.position, Quaternion.identity);
        }
    }
}
