using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public enum GameStatus { Running, Paused, Dialog, GameOver }

public class GameController : MonoBehaviour
{
    public GameStatus gameStatus = GameStatus.Running;

    public GameObject defaultCamera;

    public bool canExit = false;

    public GameObject pauseCanvasObj;

    private static GameController _instance;

    public static GameController Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Start()
    {
        _instance = this;
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(pauseCanvasObj);
    }

    public void ReturnToNormalCam(GameObject minigameCamera, GameObject minigameObj)
    {
        defaultCamera.SetActive(true);

        minigameObj.SetActive(false);

        PlayerScript.Instance.gameObject.GetComponent<PlayerInput>().enabled = true;

        minigameCamera.SetActive(false);
    }

    public void SwitchCam(GameObject minigameCamera, GameObject minigameObj)
    {
        defaultCamera.SetActive(false);

        minigameCamera.SetActive(true);

        PlayerScript.Instance.gameObject.GetComponent<PlayerInput>().enabled = false;

        minigameObj.SetActive(true);
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        canExit = false;
    }

    public void OnPause()
    {
        //GameObject playerToDeactivate;

        if (pauseCanvasObj.activeSelf)
        {
            pauseCanvasObj.SetActive(false);
            PlayerScript.Instance.gameObject.GetComponent<PlayerInput>().enabled = true;
            //playerToDeactivate = FindObjectOfType<PlayerInput>().gameObject;
            //playerToDeactivate.GetComponent<PlayerInput>().enabled = true;
        }
        else if(!pauseCanvasObj.activeSelf)
        {
            PlayerScript.Instance.gameObject.GetComponent<PlayerInput>().enabled = false;
            //playerToDeactivate = FindObjectOfType<PlayerInput>().gameObject;
            //playerToDeactivate.GetComponent<PlayerInput>().enabled = false;
            pauseCanvasObj.SetActive(true);
        }
    }
}
