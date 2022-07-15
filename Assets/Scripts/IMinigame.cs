using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMinigame : MonoBehaviour
{
    public void ExitMinigame()
    {
        if (PlayerScript.Instance.eventObj != null)
        {
            GameController.Instance.ReduceCanExitCounter();

            GameController.Instance.ReturnToNormalCam(PlayerScript.Instance.eventObj.minigameCamera,
            PlayerScript.Instance.eventObj.minigameObj);

            Destroy(PlayerScript.Instance.eventObj.gameObject);
        } 
    }

    public void OnReturnToPlayer()
    {
        GameController.Instance.ReturnToNormalCam(PlayerScript.Instance.eventObj.minigameCamera,
            PlayerScript.Instance.eventObj.minigameObj);
    }

    private void OnPause()
    {
        GameController.Instance.OnPause();
    }
}
