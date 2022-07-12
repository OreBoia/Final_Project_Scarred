using Cinemachine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneScript : MonoBehaviour
{
    //Set Animation
    //Riferimento Oggetto/i da controllare
    //Minigiochi (se ci sono)
    //Dialoghi (se ci sono)

    //Prima cutscene
    //

    public GameObject[] objectToActivate;
    public GameObject[] objectToDeactivate;
    public GameObject cutscenePlayer;
    public DialogScriptableObject dialogAsset;

    //private void Update()
    //{
    //    GameController.Instance.defaultCamera.GetComponent<CinemachineBrain>().
    //        ActiveVirtualCamera.Follow = cutscenePlayer.transform;
    //}

    private void WakeUp()
    {
        cutscenePlayer.GetComponent<SkeletonAnimation>().AnimationName = 
            Interaction.jason_letto_si_sveglia.ToString();
    }
}
