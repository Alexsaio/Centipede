using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float force = 600f;
    public float destroyTime = 1f;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        rb.AddForce(Vector2.up * force);
        Destroy(gameObject, destroyTime);
    }

    void OnDestroy()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().shootEnable = true;
    }
}
