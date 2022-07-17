using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCanExitCounter : MonoBehaviour
{
    public int canExitCounter;

    private void Update()
    {
        if (canExitCounter == 0)
        {
            GameController.Instance.canExit = true;
            Destroy(this.gameObject);
        }

        if (GameController.Instance)
        {
            GameController.Instance.SetCanExitCounter(canExitCounter);
            GameController.Instance.defaultCamera = FindObjectOfType<CinemachineBrain>().gameObject;
            Destroy(this.gameObject);
        }
        
    }
}
