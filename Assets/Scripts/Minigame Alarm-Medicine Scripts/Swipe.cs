using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    BoxCollider2D[] colliderList;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EndMinigame swipeDone = collision.gameObject.GetComponent<EndMinigame>();

        if (swipeDone != null)
        {
            MinigameAlarmController.Instance.ExitMinigame();
        }
    }
}
