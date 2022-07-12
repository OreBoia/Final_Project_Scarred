using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    PolygonCollider2D doorCollider;
    SpriteRenderer sp;
    public float RotY;
    public GameObject intIcon;

    public void Open()
    {
        doorCollider = GetComponent<PolygonCollider2D>();
        sp = GetComponent<SpriteRenderer>();

        doorCollider.enabled = false;
        this.gameObject.transform.parent.transform.rotation = 
            new Quaternion(0f, RotY, 0f, 0f);

        Destroy(intIcon);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerScript player = collision.gameObject.GetComponent<PlayerScript>();

        if (player != null)
        {
            player.door = this.gameObject;
            intIcon.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        PlayerScript player = collision.gameObject.GetComponent<PlayerScript>();

        if (player != null && player.door != null)
        {
            player.door = null;
            intIcon.SetActive(false);
        }
    }
}
