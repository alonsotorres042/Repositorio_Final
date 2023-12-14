using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "GameData", menuName = "ScriptableObjects/GameData", order = 1)]
public class GameData : ScriptableObject
{
    //GENERAL INFO
    public Transform Player;
    public Transform Sight;

    //ENEMY STUFF
    public SpriteRenderer EnemySP;
    public EnemyController Enemy;
    public int EnemyLife = 10000;
    public int CurrenEnemytLife;
}
