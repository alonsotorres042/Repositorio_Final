using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public GameData GameData;
    private RaycastHit hit;
    public float RaycastLenght;
    public LayerMask Layer;
    private Vector3 _shotDirection;
    public float BulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _shotDirection = (transform.position - GameData.Player.position) * -1;
        _shotDirection.Normalize();
        transform.LookAt(GameData.Player);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + _shotDirection * BulletSpeed;
    }
    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, _shotDirection, out hit, RaycastLenght, Layer))
        {
            if (hit.collider.name == "TestPlayer2D")
            {
                Destroy(gameObject);
            }
            Debug.DrawRay(transform.position, _shotDirection * RaycastLenght, Color.cyan);
        }
        else
        {
            Debug.DrawRay(transform.position, _shotDirection * RaycastLenght, Color.black);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.name != "Enemy")
        {
            Destroy(gameObject);
        }
    }
}