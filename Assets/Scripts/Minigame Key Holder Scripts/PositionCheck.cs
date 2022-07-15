using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionCheck : MonoBehaviour
{
    public GameObject rightPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PosObjScript p = collision.gameObject.GetComponent<PosObjScript>();

        //Debug.Log(collision.gameObject.name);

        if (p != null)
        {
            if (p.gameObject.name == rightPos.name)
            {
                this.gameObject.GetComponentInParent<CircleScript>().isInRightPos = true;
            }
            else
            {
                this.gameObject.GetComponentInParent<CircleScript>().isInRightPos = false;
            }
        }
    }
}
