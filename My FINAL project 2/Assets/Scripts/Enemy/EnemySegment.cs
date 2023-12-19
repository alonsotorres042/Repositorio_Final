using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPart : MonoBehaviour
{
    public GameData gameData;
    private SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (_spriteRenderer.color == gameData.Enemy.HurtColor)
        {
            _spriteRenderer.color = Color.white;
        }
    }
    void GetThisDamage()
    {
        gameData.CurrenEnemyLife = gameData.CurrenEnemyLife - gameData.Player.Bullet.GetComponent<BulletController>().BulletDamage;
    }
}
