using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject AttackZone;
    public GameObject EnemyBullet;
    public EnemyBulletController BulletControl;
    public Transform Player;
    public Transform EnemyBulletSpawner;
    private IEnumerator corutineFunction;

    private void Awake()
    {
        corutineFunction = ShootPlayer(1f);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(corutineFunction);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);
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
