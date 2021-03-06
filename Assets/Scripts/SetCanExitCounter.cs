using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCanExitCounter : MonoBehaviour
{
    public int canExitCounter;

    private void Update()
    {

        if (GameController.Instance)
        {
            if (canExitCounter == 0)
            {
                GameController.Instance.canExit = true;
                Destroy(this.gameObject);
            }
            GameController.Instance.SetCanExitCounter(canExitCounter);
            GameController.Instance.defaultCamera = FindObjectOfType<CinemachineBrain>().gameObject;
            Destroy(this.gameObject);
        }
        
    }
}
