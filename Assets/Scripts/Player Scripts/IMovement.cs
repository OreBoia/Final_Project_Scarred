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
    private Rigidbody2D rigidbody2d;
    private SkeletonAnimation sp;

    PlayerInput playerInput;

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
                ChangeAnimation("jason_camminata");
                sp.Skeleton.SetSkin("verso sx");
                sp.Skeleton.ScaleX = -1;
            }
            else if (movementVector.x > 0f)
            {
                ChangeAnimation("jason_camminata");
                sp.Skeleton.SetSkin("verso dx");
                sp.Skeleton.ScaleX = 1;
            }
            else if (movementVector.x == 0f)
            {
                ChangeAnimation("jason_idle");
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
