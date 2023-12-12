using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    private Vector3 _shotDirection;
    public float BulletSpeed;
    public Transform Target;
    // Start is called before the first frame update
    void Start()
    {
        _shotDirection = transform.position - Target.position;
        _shotDirection.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (_shotDirection * -1) * BulletSpeed;
    }
}
