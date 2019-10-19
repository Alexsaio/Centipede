using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector2 positionPlayer;
    float speed = 5f;
    float limitX = 6f;
    public GameObject bulletPrefab;
    Transform bulletposition;

    public bool shootEnable = true; 

    void Start()
    {
        positionPlayer = transform.position;
        bulletposition = transform.Find("BulletLabel");
    }

    void Update()
    {
        Move();
        Shoot();
    }

    void Move()
    {
        positionPlayer.x += Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        positionPlayer.x = Mathf.Clamp(positionPlayer.x, -limitX, limitX);
        transform.position = positionPlayer;
    }

    void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Space) && shootEnable)
        {
            shootEnable = false;
            Instantiate(bulletPrefab, bulletposition.position, Quaternion.identity);
        }
    }
}
