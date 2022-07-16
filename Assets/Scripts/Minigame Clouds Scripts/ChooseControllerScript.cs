using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChooseControllerScript : IMinigame
{
    public GameObject[] chooseObjects;

    public int index;
    public int assetIndex;

    public Image cloudToChange;
    public GameObject[] newClouds;

    private void Start()
    {
        ChangeSelectionColorFrame(Color.blue);
        
    }

    private void Update()
    {
        DialogController.Instance.PrintSpeakers();

        if (DialogController.Instance.dialogStatus == DialagoStatus.EndOfDialog)
        {
            Debug.Log("NEW CLOUD");
        }

        //chooseObjects[assetIndex].gameObject.transform.GetComponentInChildren<TextMeshProUGUI>().text = chooseObjects[assetIndex].GetComponent<DialogAssetChoose>().dialog[assetIndex].name;
        //for (int i = 0; i < chooseObjects[assetIndex].gameObject.transform.childCount; i++)
        //{
        //    Debug.Log(chooseObjects[assetIndex].gameObject.transform.GetChild(i));
        //}
        
    }

    public void OnMovePositionRight()
    {
        ChangeSelectionColorFrame(Color.white);

        if (index < 2)
        {
            index++;
        }

        ChangeSelectionColorFrame(Color.blue);
    }

    public void OnMovePositionLeft()
    {
        ChangeSelectionColorFrame(Color.white);

        if (index > 0)
        {
            index--;
        }

        ChangeSelectionColorFrame(Color.blue);
    }

    public void OnSelectChoose()
    {
        Debug.Log($"Choose {index} - {chooseObjects[index]}");

        //Le scelte devono sparire dallo schermo
        ActiveDeatctiveChooseFrame();
        //Inizia dialogo 
        StartDialog();
        //Alla fine del dialogo:
        //  - nuova nuvola
        //  - nuove scelte
        //index++;
        

    }

    private void StartDialog()
    {
        DialogController.Instance.dialogAsset = chooseObjects[index].GetComponent<DialogAssetChoose>().dialog[assetIndex];
        DialogController.Instance.AddSpeaker();
        DialogController.Instance.setPointObj = null;

        DialogScript ds = GetComponent<DialogScript>();

        ds.OnEventInteraction();
    }

    private void ActiveDeatctiveChooseFrame()
    {
        
    }

    public void ChangeSelectionColorFrame(Color newColor)
    {
        chooseObjects[index].GetComponent<Image>().color = newColor;
    }

    public void EndOfDialogChanges()
    {
        if (assetIndex < 2)
        {
            assetIndex++;
            newClouds[assetIndex].SetActive(true);
            foreach (GameObject co in chooseObjects)
            {
                co.gameObject.GetComponentInChildren<TextMeshProUGUI>().text =
                    co.GetComponent<DialogAssetChoose>().dialog[assetIndex].name;
            }
        }
        else
        {
            DialogController.Instance.sortedSpeakerList.Remove(1);


            ExitMinigame();
        }      
    }
}
