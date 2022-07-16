using UnityEngine;

public class HandScripts : IMovement
{
    [SerializeField]
    LeafScripts leafObj;

    [SerializeField]
    SpriteRenderer spHand;
    public Sprite normalSprite;
    public Sprite leafInHandSprite;

    private void Awake()
    {
        spHand = this.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        MovePlayer();
        IsMove();
    }

    private void IsMove()
    {
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