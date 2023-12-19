using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerControl : MonoBehaviour
{
    public GameData gameData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameData.CurrenEnemyLife == 0)
        {
            Victory();
        }else if(gameData.CurrenPlayerLife == 0)
        {
            Defeat();
        }
    }
    void Victory()
    {
        gameData.Enemy.gameObject.SetActive(false);
    }
    void Defeat()
    {
        gameData.Player.gameObject.SetActive(false);
    }
}
