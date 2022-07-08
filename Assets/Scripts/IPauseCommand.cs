using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IPauseCommand : MonoBehaviour
{
    private void OnPause()
    {
        GameController.Instance.OnPause();
    }
}
