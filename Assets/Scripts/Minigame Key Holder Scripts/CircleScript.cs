using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScript : MonoBehaviour
{
    public void Rotate(float z)
    {
        transform.Rotate(new Vector3(0f,0f,z));
    }
}
