using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseSelectorScript : MonoBehaviour
{
    Rigidbody2D rb;
    RaycastHit2D raycast;
    public Vector2 raycastOffset;
    public Vector2 dir;
    public GameObject defaultButton;
    private GameObject prevButton;
    private GameObject actualButton;

    public bool pressToMenu;
    public GameObject initMenu;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        actualButton = defaultButton;
        //actualButton.GetComponent<Image>().color = Color.red;

        this.transform.position = actualButton.gameObject.transform.position;
    }

    private void OnMove(InputValue value)
    {
        //Debug.Log(value.Get<Vector2>());

        Vector2 raycastOffsetDir = Vector2.zero;
        raycastOffsetDir.y = raycastOffset.y * value.Get<Vector2>().y;

        dir.y = value.Get<Vector2>().y;
        dir.x = 0;

        raycast = Physics2D.Raycast(new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y) + raycastOffsetDir,
            dir, Mathf.Infinity);

        //Debug.Log(raycast.collider.gameObject.name);
        if (raycast.collider != null)
        {
            prevButton = actualButton;
            actualButton = raycast.collider.gameObject;

            //ChangeColorButton();

            this.transform.position = raycast.collider.gameObject.transform.position;
        } 
    }

    private void ChangeColorButton()
    {
        //prevButton.GetComponent<Image>().color = Color.white;
        //actualButton.GetComponent<Image>().color = Color.red;
    }

    private void OnSelect()
    {
        if (!pressToMenu)
        {
            switch (actualButton.gameObject.name)
            {
                case "ReturnButton":
                    GameController.Instance.OnPause();
                    break;
                case "ExitButton":
                    Application.Quit();
                    break;
                case "StartButton":
                    SceneManager.LoadScene("1LVL1Letterainiziale");
                    break;
            }
        }
    }

    private void OnPressToMenu()
    {
        if (pressToMenu)
        {
            Destroy(initMenu);
            pressToMenu = false;
        }
    }
}
