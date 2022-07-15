using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameKeyHolderController : IMinigame
{
    public CircleScript circle1;
    public CircleScript circle2;
    public CircleScript circle3;
    public CircleScript circle4;

    public int index;

    private void OnMoveSelectionNext()
    {
        if (index < 3)
        {
            index++;
        }

        ChangeCircleSprite(-1);
    }
    private void OnMoveSelectionPrevius()
    {
        if (index > 0)
        {
            index--;
        }

        ChangeCircleSprite(1);
    }
    private void ChangeCircleSprite(int prevCircle)
    {
        Debug.Log("CHANGE");
        //glow
        switch (index)
        {
            case 0:
                circle1.ChangeSpriteToGlow();
                circle3.ChangeSpriteToGlow();
                break;
            case 1:
                circle2.ChangeSpriteToGlow();
                circle4.ChangeSpriteToGlow();
                break;
            case 2:
                circle3.ChangeSpriteToGlow();
                break;
            case 3:
                circle4.ChangeSpriteToGlow();
                circle1.ChangeSpriteToGlow();
                break;
        }

        //normal
        switch (index + prevCircle)
        {
            case 0:
                circle1.ChangeSpriteToNormal();
                circle3.ChangeSpriteToNormal();
                break;
            case 1:
                circle2.ChangeSpriteToNormal();
                circle4.ChangeSpriteToNormal();
                break;
            case 2:
                circle3.ChangeSpriteToNormal();
                break;
            case 3:
                circle4.ChangeSpriteToNormal();
                circle1.ChangeSpriteToNormal();
                break;
        }
    }

    

    private void OnRotateInteraction()
    {
        switch (index)
        {
            case 0:
                circle1.Rotate(-60f);
                circle3.Rotate(-60f);
                break;
            case 1:
                circle2.Rotate(-60f);
                circle4.Rotate(60f);
                break;
            case 2:
                circle3.Rotate(-60f);
                break;
            case 3:
                circle4.Rotate(-60f);
                circle1.Rotate(-60f);
                break;
        }

        CheckAllRightPosition();
        //circle1.Rotate(-60f);
    }

    private void CheckAllRightPosition()
    {
        if (circle1.isInRightPos)
        {
            if (circle2.isInRightPos)
            {
                if (circle3.isInRightPos)
                {
                    if (circle4.isInRightPos)
                    {
                        Debug.Log("WIN");
                        ExitMinigame();
                    }
                }
            }
        }
    }
}
