using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScript : MonoBehaviour
{
    public bool isInRightPos;

    public SpriteRenderer sp;

    public Sprite normal;
    public Sprite glow;

    private void Start()
    {
        //sp = this.GetComponentInChildren<SpriteRenderer>();    
    }

    public void Rotate(float z)
    {
        transform.Rotate(new Vector3(0f,0f,z));
    }

    public void ChangeSpriteToNormal()
    {
        sp.color = Color.white;
    }
    
    public void ChangeSpriteToGlow()
    {
        Color c = new Color(255, 120, 100);
        sp.color = Color.red;
    }
}
