using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameLeafController : IMinigame
{
    public EyeScript eye;
    public HandScripts hand;
    public bool isWatching;
    public bool endMinigame;

    private static MinigameLeafController _instance;

    public static MinigameLeafController Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Update()
    {
        isWatching = eye.isWatching;

        if (isWatching && hand.inMovement)
        {
            endMinigame = true;
        }

        if (!GameObject.FindObjectOfType<LeafScripts>())
        {
            endMinigame = true;
        }

        if (endMinigame)
        {
            //GameOver
            ExitMinigame();
        }
    }
}
