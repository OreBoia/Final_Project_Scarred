using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameCandlesController : IPauseCommand
{
    RaycastHit2D raycast;
    
    public CandleScript actualCandle;

    public List<GameObject> candlesList = new List<GameObject>();
    public CandleScript[] selectedCandlesArray = new CandleScript[2];

    Rigidbody2D rigidbodyController;

    int raycastLayer;

    //public Vector2 raycastOffset;

    private void Start()
    {
        //selectedCandlesArray = new CandleScript[2];

        rigidbodyController = GetComponent<Rigidbody2D>();

        raycastLayer = 1 << 8;
    }

    private void Update()
    {
        //actualCandle.ChangeSpriteSelected();
        foreach (CandleScript c in selectedCandlesArray)
        {
            if (c != null)
            {
                c.ChangeSpriteSelected();
            }
        }
    }

    private void OnSelectCandle()
    {
        Debug.Log("SELECT");

        

        SelectedCandlesFullCheck();

        for (int i = 0; i < 2; i++)
        {
            if (selectedCandlesArray[i] != null)
            {
                if (selectedCandlesArray[i].name == actualCandle.name)
                {
                    break;
                }
            }
            
            if (selectedCandlesArray[i] == null)
            {
                selectedCandlesArray[i] = actualCandle;
                break;
            }
        }

        foreach (CandleScript c in selectedCandlesArray)
        {
            if (c != null)
            {
                c.ChangeSpriteSelected();
            }
        }

        SwapCandle();
    }

    private void OnMovePositionUp()
    {
        CheckPosition(Vector2.up, new Vector2(0f, 0.1f));
    }

    private void OnMovePositionDown()
    {
        CheckPosition(Vector2.down, new Vector2(0f, -0.1f));
    }

    private void OnMovePositionLeft()
    {
        CheckPosition(Vector2.left, new Vector2(-0.1f, 0f));
    }

    private void OnMovePositionRight()
    {
        CheckPosition(Vector2.right, new Vector2(0.1f, 0f));
    }

    private void CheckPosition(Vector2 dir, Vector2 raycastOffset)
    {
        //Debug.Log($"SHOOT: - O {new Vector2(this.transform.position.x, this.transform.position.y) + raycastOffset + dir} - D {dir}" );

        raycast = Physics2D.Raycast(new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y) + raycastOffset + dir,
            dir, Mathf.Infinity, raycastLayer);

        if (raycast.collider != null)
        {
            //Debug.Log("HIT " + raycast.collider.gameObject.name);

            CandleScript candleHit = raycast.collider.gameObject.GetComponent<CandleScript>();

            if (candleHit != null && candleHit.gameObject.name != actualCandle.name)
            {
                candlesList.Add(candleHit.gameObject);
                rigidbodyController.MovePosition(candleHit.gameObject.transform.position);
            }
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CandleScript candle = collision.gameObject.GetComponent<CandleScript>();

        if (candle != null)
        {
            actualCandle = collision.gameObject.GetComponent<CandleScript>();
            actualCandle.ChangeSpriteSelected();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CandleScript candle = collision.gameObject.GetComponent<CandleScript>();

        if (candle != null)
        {
            candle.ChangeSpriteNotSelected();
        }
    }

    private void SwapCandle()
    {
        if (selectedCandlesArray[0] != null && selectedCandlesArray[1] != null)
        {
            Vector2 saveActualPos0 = selectedCandlesArray[0].actualPosition.gameObject.transform.position;
            Vector2 saveActualPos1 = selectedCandlesArray[1].actualPosition.gameObject.transform.position;

            if (Near())
            {
                selectedCandlesArray[0].SwapCandlePosition(saveActualPos1);
                selectedCandlesArray[1].SwapCandlePosition(saveActualPos0);
                //selectedCandlesArray[0].ChangeSpriteNotSelected();
                //selectedCandlesArray[1].ChangeSpriteNotSelected();
            }

            ClearArray();
        }
    }

    private bool Near()
    {
        
        foreach (PlacePointScript place in selectedCandlesArray[1].actualPosition.neighbors)
        {
            if(selectedCandlesArray[0].actualPosition.gameObject.name == place.gameObject.name)
            {
                return true;
            }
        }

        ClearArray();

        return false;
    }

    private void SelectedCandlesFullCheck()
    {
        if (selectedCandlesArray[0] != null && selectedCandlesArray[1] != null)
        {
            ClearArray();

            selectedCandlesArray[0] = actualCandle;
        }
    }

    private void ClearArray()
    {
        CandleScript temp;

        temp = selectedCandlesArray[0];
        selectedCandlesArray[0] = null;
        if (temp != null)
        {
            temp.ChangeSpriteNotSelected();
        }
        
        temp = selectedCandlesArray[1];
        selectedCandlesArray[1] = null;
        if (temp != null)
        {
            temp.ChangeSpriteNotSelected();
        }
    }
}
