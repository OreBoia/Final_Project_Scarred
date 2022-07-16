using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAlarmScripts : IMovement
{
    //public Paper paperGrabed;
    BoxCollider2D handCollider;
    Rigidbody2D rbHand;
    bool raycast;
    public RaycastHit raycastHitInfo;
    public SpriteRenderer spHand;
    public Sprite grabSprite;
    public Sprite releaseSprite;

    private void Awake()
    {
        handCollider = GetComponent<BoxCollider2D>();
        rbHand = GetComponent<Rigidbody2D>();
        spHand = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        MovePlayer();

    }

    private void OnGrab()
    {
        Debug.Log("GRAB");

        spHand.sprite = grabSprite;

        Ray ray = new Ray(this.gameObject.transform.position + new Vector3(0, 3.5f, 0),
            new Vector3(0, 0, 1));

        raycast = Physics.Raycast(ray, out raycastHitInfo, Mathf.Infinity);

        Debug.Log(raycastHitInfo.collider);

        if (raycastHitInfo.collider != null)
        {
            if (raycastHitInfo.collider.gameObject.GetComponent<Paper>() ||
            raycastHitInfo.collider.gameObject.GetComponent<Swipe>())
            {
                if (raycastHitInfo.collider.gameObject.transform.parent.gameObject.name == "MedObj")
                {
                    MinigameAlarmController.Instance.ExitMinigame();
                }

                raycastHitInfo.collider.gameObject.transform.parent =
                     this.gameObject.transform;
            }
        }
    }

    private void OnRelease()
    {
        Debug.Log("RELEASE");
        //Debug.Log("PAPER CHILD: " + GetComponentInChildren<Paper>().gameObject);

        spHand.sprite = releaseSprite;

        if (GetComponentInChildren<Paper>() )
        {
            GetComponentInChildren<Paper>().gameObject.transform.parent = 
                        this.gameObject.transform.parent;
        }

        if (GetComponentInChildren<Swipe>())
        {
            GetComponentInChildren<Swipe>().gameObject.transform.parent =
                        this.gameObject.transform.parent;
        }
    }
}
