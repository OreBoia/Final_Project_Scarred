using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTest : IMovement
{
    private void Update()
    {
        MovePlayer();

        if (movementVector == Vector2.zero)
        {
            inMovement = false;
        }
        else
        {
            inMovement = true;
        }
    }
}
