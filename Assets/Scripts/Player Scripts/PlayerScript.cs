using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : IPauseCommand
{
    public GameObject door;
    public GameObject leftBubblePos;
    public GameObject rightBubblePos;

    public EventScript eventObj;

    //INSTANCE
    private static PlayerScript _instance;

    public static PlayerScript Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Start()
    {
        _instance = this;
        //Debug.Log(Interaction.jason_idle.ToString());
    }

    public void OnEventInteraction()
    {
        if (door != null)
        {
            door.GetComponent<DoorScript>().Open();
            door = null;
        }

        //if (eventObj != null)
        //{
        //    eventObj.SwitchCam();
        //}
    }

    
}
