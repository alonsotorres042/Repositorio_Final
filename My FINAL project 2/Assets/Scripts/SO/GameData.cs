using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (fileName = "GameData", menuName = "ScriptableObjects/GameData", order = 1)]
public class GameData : ScriptableObject
{
    //GENERAL INFO
    public Transform Sight;
    public float Score = 0;

    //ENEMY STUFF
    public EnemyController Enemy;
    public float EnemyLife;
    public float CurrenEnemyLife;
    public Image EnemyLifeBar;

    //PLAYER STUFF
    public PlayerControl Player;
    public float PlayerLife;
    public float CurrenPlayerLife;
}
