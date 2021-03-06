using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IPauseCommand : MonoBehaviour
{
    private void OnPause()
    {
        if (this.gameObject.GetComponent<PlayerScript>())
        {
            GameController.Instance.OnPause();
        }  
    }

    public void OnReturnToPlayer()
    {
        GameController.Instance.ReturnToNormalCam(PlayerScript.Instance.eventObj.minigameCamera,
            PlayerScript.Instance.eventObj.minigameObj);
    }
}
