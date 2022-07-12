using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject playerReference;
    public float minDistanceToMove;
    public float speed;
    public float distanceOffset;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //playerReference = PlayerScript.Instance.gameObject;
    }

    private void Update()
    {
        Follow();
    }

    private void Follow()
    {
        float distance = Vector2.Distance(rb.position, playerReference.GetComponent<Rigidbody2D>().position);

        Debug.Log("DISTANCE: " + distance);

        if (distance > minDistanceToMove)
        {
            if (playerReference.GetComponent<Rigidbody2D>().position.x > rb.position.x)
            {
                rb.MovePosition(Vector2.Lerp(rb.position,playerReference.GetComponent<Rigidbody2D>().position -
                new Vector2(distanceOffset, 0f), speed * Time.deltaTime));
            }
            else
            {
                rb.MovePosition(Vector2.Lerp(rb.position, playerReference.GetComponent<Rigidbody2D>().position -
                new Vector2(distanceOffset*-1, 0f), speed * Time.deltaTime));
            }
        } 
    }
}
