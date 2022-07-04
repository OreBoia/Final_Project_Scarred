using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EndMinigame swipeDone = collision.gameObject.GetComponent<EndMinigame>();

        if (swipeDone != null)
        {
            GetComponent<BoxCollider2D>().enabled = false;

            this.transform.parent = MinigameAlarmController.Instance.transform;

            MinigameAlarmController.Instance.ExitMinigame();
        }
    }
}
