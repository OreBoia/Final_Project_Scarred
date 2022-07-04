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
    }

    private void OnMoveSelectionPrevius()
    {
        if (index > 0)
        {
            index--;
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
        //circle1.Rotate(-60f);
    }
}
