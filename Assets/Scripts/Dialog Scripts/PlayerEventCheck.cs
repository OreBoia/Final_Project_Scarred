using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EventScript eventObj = collision.gameObject.GetComponent<EventScript>();
        //Debug.Log(eventObj);

        if (eventObj != null)
        {
            PlayerScript.Instance.eventObj = eventObj;

            DialogController.Instance.dialogAsset = eventObj.dialogAsset;
            DialogController.Instance.AddSpeaker();
            DialogController.Instance.setPointObj = eventObj.setPoint;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        EventScript eventObj = collision.gameObject.GetComponent<EventScript>();

        //Debug.Log("COLLISION " + collision);

        if (PlayerScript.Instance.eventObj != null)
        {
            PlayerScript.Instance.eventObj = null;
        }

        if (eventObj != null)
        {
            DialogController.Instance.Reset();
            //aggiungere controllo quando non c'è il dialog asset
        }
    }
}
