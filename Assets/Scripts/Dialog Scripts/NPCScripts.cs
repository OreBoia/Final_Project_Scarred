using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScripts : MonoBehaviour
{
    public int id;

    SkeletonAnimation sp;

    private void Start()
    {
        sp = GetComponent<SkeletonAnimation>();
    }

    public void ChangeAnimation(string animationName)
    {
        if (sp != null)
        {
            sp.AnimationName = animationName;
        }
    }

}
