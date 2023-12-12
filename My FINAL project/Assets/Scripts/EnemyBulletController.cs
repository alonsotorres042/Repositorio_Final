using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public GameData GameData;
    private Vector3 _shotDirection;
    public float BulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        //_shotDirection = transform.position - Target.position;
        _shotDirection = (transform.position - GameData.Player.position) * -1;
        _shotDirection.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + _shotDirection * BulletSpeed;
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "TestPlayer2D")
        {
            Debug.Log(other.gameObject.name);

        }
        Destroy(gameObject);
    }
}
