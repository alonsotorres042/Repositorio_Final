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

    private void Awake()
    {
        corutineFunction = ShootPlayer(Cadency);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(corutineFunction);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(GameData.Player);
        if (Input.GetKeyDown(KeyCode.C))
        {
            StopCoroutine(corutineFunction);
        }
    }
    IEnumerator ShootPlayer(float Cadency)
    {
        while (true)
        {
            Instantiate(EnemyBullet, EnemyBulletSpawner.position, Quaternion.identity);
            yield return new WaitForSeconds(Cadency);
        }
    }
}
