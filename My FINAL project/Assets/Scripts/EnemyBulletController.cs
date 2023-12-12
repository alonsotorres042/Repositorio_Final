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
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + _shotDirection * BulletSpeed;
    }
    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, RaycastLenght, Layer))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * RaycastLenght, Color.yellow);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * RaycastLenght, Color.white);
        }
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