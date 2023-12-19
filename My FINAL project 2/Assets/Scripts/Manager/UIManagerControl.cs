using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManagerControl : MonoBehaviour
{
    public GameData gameData;
    public Image EnemyBar;
    public Image PlayerBar;
    public Image VictoryScreen;
    public Image DefeatScreen;
    public Button RetunrMenu;
    public IEnumerator SlideAction;
    // Start is called before the first frame update
    void Start()
    {
        SlideAction = SlideScreens();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerBar.fillAmount = gameData.CurrenPlayerLife / gameData.PlayerLife;
        EnemyBar.fillAmount = gameData.CurrenEnemyLife / gameData.EnemyLife;
        PlayerBar.transform.position = Camera.main.WorldToScreenPoint(new Vector3(gameData.Player.transform.position.x, gameData.Player.transform.position.y - 0.2f, gameData.Player.transform.position.z));
    }
    void FixedUpdate()
    {
        if (gameData.CurrenEnemyLife == 0 || gameData.CurrenPlayerLife == 0)
        {
            StartCoroutine(SlideAction);
            RetunrMenu.gameObject.SetActive(true);
        }
    }
    IEnumerator SlideScreens()
    {
        if(gameData.Victory == true)
        {
            while (true)
            {
                VictoryScreen.fillAmount = VictoryScreen.fillAmount + 0.0003f;
                yield return 0.1f;
            }
        }
        else if(gameData.Victory == false)
        {
            while (true)
            {
                DefeatScreen.fillAmount = DefeatScreen.fillAmount + 0.0003f;
                yield return 0.1f;
            }
        }
    }
}