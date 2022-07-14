using Spine.Unity;
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

    public string walkAnimName;
    public string idleAnimName;
    //public string skinDx;
    //public string skinSx;
    public int flipValuePos;
    public int flipValueneg;

    SkeletonAnimation skelAnim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //playerReference = PlayerScript.Instance.gameObject;
        skelAnim = GetComponent<SkeletonAnimation>();
    }

    private void Update()
    {
        if (playerReference == null)
        {
            if (PlayerScript.Instance)
            {
                playerReference = PlayerScript.Instance.gameObject;
            }           
        }

        if (DialogController.Instance.dialogStatus == DialagoStatus.Init)
        {
            Follow();
        }
    }

    private void Follow()
    {
        float distance = Vector2.Distance(rb.position, playerReference.GetComponent<Rigidbody2D>().position);

        //Debug.Log("DISTANCE: " + distance);

        if (distance > minDistanceToMove)
        {
            if (playerReference.GetComponent<Rigidbody2D>().position.x > rb.position.x)
            {
                rb.MovePosition(Vector2.Lerp(rb.position,playerReference.GetComponent<Rigidbody2D>().position -
                new Vector2(distanceOffset, 0f), speed * Time.deltaTime));

                ChangeAnimation(walkAnimName);
                //sp.Skeleton.SetSkin(skinSx);
                skelAnim.Skeleton.ScaleX = flipValuePos;
            }
            else
            {
                rb.MovePosition(Vector2.Lerp(rb.position, playerReference.GetComponent<Rigidbody2D>().position -
                new Vector2(distanceOffset*-1, 0f), speed * Time.deltaTime));

                ChangeAnimation(walkAnimName);
                //sp.Skeleton.SetSkin(skinSx);
                skelAnim.Skeleton.ScaleX = flipValueneg;
            }
        }
        else
        {
          
            ChangeAnimation(idleAnimName);
        
        }
    }

    public void ChangeAnimation(string animationName)
    {
        if (skelAnim != null)
        {
            skelAnim.AnimationName = animationName;
        }
    }
}
