using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameAlarmController : IMinigame
{
    private static MinigameAlarmController _instance;

    public static MinigameAlarmController Instance
    {
        get
        {
            return _instance;
        }
    }
}
