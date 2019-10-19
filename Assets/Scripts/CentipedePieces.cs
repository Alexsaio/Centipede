using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentipedePieces : MonoBehaviour
{
    public GameObject centipedeHead;
    public GameObject centipedeBody;
    public int leghtCentipede = 6;
    public int spaceBetween = 1; // space between centipede's body and head
    public bool moveEnable = true; // can move
    public bool moveRight = true;
    public float leghtStep = 0.7f;
    public float speedStep = 0.1f; // centipede's speed

    void Awake()
    {
        for (int j = 0; j < leghtCentipede; j++)
        {
            Vector2 positionX = new Vector2(transform.position.x + j, transform.position.y);
            GameObject Body = Instantiate(centipedeBody.gameObject, positionX, Quaternion.identity);
            Body.transform.SetParent(this.transform);
        }
        Vector2 positionHead = new Vector2(transform.position.x + leghtCentipede + spaceBetween, transform.position.y);
        GameObject Head = Instantiate(centipedeHead.gameObject, positionHead, Quaternion.identity);
        Head.transform.SetParent(this.transform);
    }

    void Start()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (moveEnable)
        {
            Vector2 direction = moveRight ? Vector2.right : Vector2.left;
            transform.Translate(direction * leghtStep);
            yield return new WaitForSeconds(speedStep);
        }
    }

    public void TouchBorder()
    {
        moveRight = !moveRight;
        transform.Translate(Vector2.down * leghtStep);
    }
}

