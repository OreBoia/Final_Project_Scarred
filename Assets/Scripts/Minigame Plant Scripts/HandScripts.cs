using UnityEngine;

public class HandScripts : IMovement
{
    [SerializeField]
    LeafScripts leafObj;

    private void Update()
    {
        MovePlayer();

        if (movementVector == Vector2.zero)
        {
            inMovement = false;
        }
        else
        {
            inMovement = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LeafScripts leaf = collision.gameObject.GetComponent<LeafScripts>();

        if (leaf != null)
        {
            leafObj = leaf;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        leafObj = null;
    }

    private void OnTear()
    {
        if (leafObj != null)
        {
            leafObj.GetDamage();
        }
    }
}
