using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerControl : MonoBehaviour
{
    public GameData gameData;
    public Image EnemyBar;
    public Image PlayerBar;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerBar.fillAmount = gameData.CurrenPlayerLife / gameData.PlayerLife;
        EnemyBar.fillAmount = gameData.CurrenEnemyLife / gameData.EnemyLife;
        PlayerBar.transform.position = Camera.main.WorldToScreenPoint(new Vector3(gameData.Player.transform.position.x, gameData.Player.transform.position.y - 0.2f, gameData.Player.transform.position.z));
    }
}