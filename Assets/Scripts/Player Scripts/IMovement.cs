using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IMovement : MonoBehaviour
{
    public Vector2 movementVector;
    public float speed;
    public bool inMovement;
    
    public Rigidbody2D rigidbody2d;

    private SkeletonAnimation sp;
    public string walkAnimName;
    public string idleAnimName;
    public string skinDx;
    public string skinSx;
    public int flipValuePos;
    public int flipValueneg;


    public PlayerInput playerInput;

    //[SerializeField]
    //string scheme;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        sp = GetComponent<SkeletonAnimation>();
    }

    private void FlipWalkingAnimation()
    {
        if (sp != null)
        {
            if (movementVector.x < 0f)
            {
                ChangeAnimation(walkAnimName);
                sp.Skeleton.SetSkin(skinSx);
                sp.Skeleton.ScaleX = flipValueneg;
            }
            else if (movementVector.x > 0f)
            {
                ChangeAnimation(walkAnimName);
                sp.Skeleton.SetSkin(skinDx);
                sp.Skeleton.ScaleX = flipValuePos;
            }
            else if (movementVector.x == 0f)
            {
                ChangeAnimation(idleAnimName);
            }

            sp.Skeleton.SetSlotsToSetupPose();

            sp.LateUpdate();
        }
    }

    public void ChangeAnimation(string animationName)
    {
        if (sp != null)
        {
            sp.AnimationName = animationName;
        }
    }

    public void MovePlayer()
    {        
        Vector2 actualPosition = new Vector2(transform.position.x, transform.position.y);

        rigidbody2d.MovePosition(Vector2.Lerp(actualPosition, actualPosition + movementVector, speed));
    }

    private void OnMove(InputValue value)
    {
        movementVector = value.Get<Vector2>();
        FlipWalkingAnimation();
    }
}
