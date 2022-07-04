using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAlarmScripts : IMovement
{
    public Paper paperGrabed;
    BoxCollider2D handCollider;

    private void Awake()
    {
        handCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        MovePlayer();

        if (paperGrabed != null)
        {
            
        }
        else
        {
            
        }
    }

    private void OnGrab()
    {
        Debug.Log("GRAB");

        if (paperGrabed != null)
        {
            paperGrabed.gameObject.transform.parent =
                this.gameObject.transform;

            handCollider.enabled = false;
        }
    }

    private void OnRelease()
    {
        Debug.Log("RELEASE");
        Debug.Log("PAPER CHILD: " + GetComponentInChildren<Paper>().gameObject);

        
        GetComponentInChildren<Paper>().gameObject.transform.parent = 
            this.gameObject.transform.parent;
        //paperGrabed.gameObject.transform.parent = this.gameObject.transform.parent;
        paperGrabed = null;
        handCollider.enabled = true;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Paper paper = collision.GetComponent<Paper>();

        if (paper != null /*&& paperGrabed == null*/)
        {
            paperGrabed = paper;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //paperGrabed.gameObject.transform.parent = this.gameObject.transform.parent;
        paperGrabed = null;   
    }
}
