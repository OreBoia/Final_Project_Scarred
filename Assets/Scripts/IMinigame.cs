using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMinigame : MonoBehaviour
{
    public void ExitMinigame()
    {
        GameController.Instance.ReturnToNormalCam(PlayerScript.Instance.eventObj.minigameCamera, 
            PlayerScript.Instance.eventObj.minigameObj);
    }

}
