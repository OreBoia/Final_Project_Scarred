using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    }

    public void OnEventInteraction()
    {
        if (door != null)
        {
            door.GetComponent<DoorScript>().Open();
            door = null;
        }
    } 

    private void OnNextSceneDebug()
    {
        //Debug.Log(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
