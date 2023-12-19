using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManagerControl : MonoBehaviour
{
    public GameData gameData;
    public Image EnemyBar;
    public Image PlayerBar;
    public Image VictoryScreen;
    public Image DefeatScreen;
    public IEnumerator SlideAction;
    public IEnumerator EndCounterAction;
    public TextMeshPro Counting;
    private int EndCounter = 5;
    // Start is called before the first frame update
    void Start()
    {
        EndCounterAction = EndCounterMeth();
        SlideAction = SlideScreens();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerBar.fillAmount = gameData.CurrenPlayerLife / gameData.PlayerLife;
        EnemyBar.fillAmount = gameData.CurrenEnemyLife / gameData.EnemyLife;
        PlayerBar.transform.position = Camera.main.WorldToScreenPoint(new Vector3(gameData.Player.transform.position.x, gameData.Player.transform.position.y - 0.2f, gameData.Player.transform.position.z));

        if(gameData.CurrenEnemyLife == 0 || gameData.CurrenPlayerLife == 0)
        {
            StartCoroutine(EndCounterAction);
            StartCoroutine(SlideAction);
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
    IEnumerator EndCounterMeth()
    {
        yield return new WaitForSeconds(2);
        while (true)
        {
            yield return new WaitForSeconds(1);
            EndCounter = EndCounter - 1;
        }
    }
}