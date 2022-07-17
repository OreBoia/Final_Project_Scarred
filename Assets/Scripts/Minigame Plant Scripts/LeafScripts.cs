using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafScripts : MonoBehaviour
{
    public int leafLife = 5;
    float timeToDeath = 1f;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (leafLife <= 0)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

        if (rb.bodyType == RigidbodyType2D.Dynamic)
        {
            timeToDeath -= Time.deltaTime;
        }

        if (timeToDeath <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void GetDamage()
    {
        leafLife--;
    }
}
