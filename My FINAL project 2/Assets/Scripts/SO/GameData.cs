using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (fileName = "GameData", menuName = "ScriptableObjects/GameData", order = 1)]
public class GameData : ScriptableObject
{
    //GENERAL INFO
    public Transform Sight;
    public float Score = 0;
    public bool Victory = false;

    //ENEMY STUFF
    public EnemyController Enemy;
    public float EnemyLife;
    public float CurrenEnemyLife;

    //PLAYER STUFF
    public PlayerControl Player;
    public float PlayerLife;
    public float CurrenPlayerLife;

    //AUDIO ZONE
    public AudioClip MenuTrack;
    public AudioClip GameTrack;

    public AudioClip PlayerShot;
    public AudioClip PlayerHurt;

    public AudioClip EnemyShot;
    public AudioClip EnemyHurt;
}