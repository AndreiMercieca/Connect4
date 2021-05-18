using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public string debugStartMessage;

    public GameObject RedDisc;
    public GameObject YellowDisc;

public int heightOfBoard = 6;
public int lengthOfBoard = 7;

public GameObject[] spawnLoc;

bool RedDiscturn = true;

int[,] boardState; //0 is empty , 1 is RedDisc , 2 is YellowDisc

// 0 0 0 0 0 0 0
// 0 0 0 0 0 0 0
// 0 0 0 0 0 0 0
// 0 0 0 0 0 0 0
// 0 0 0 0 0 0 0
// 0 0 1 0 2 0 0
    
    void Start()
    {
        //Debug.Log(debugStartMessage);
        //Debug.LogError("Error");
       // Debug.LogWarning("Warning");
    
    boardState = new int[lengthOfBoard, heightOfBoard];
    }

    public void SelectColumn(int column)
    {
    //Debug.Log("GameManager Column" + column );
    TakeTurn(column);
    }

    void TakeTurn(int column)
    {
        if (updateboardState(column))
        {
if (RedDiscturn)
        {
            Instantiate(RedDisc,spawnLoc[column].transform.position,Quaternion.identity);
            RedDiscturn = false;
        }
        else
        {
            Instantiate(YellowDisc,spawnLoc[column].transform.position,Quaternion.identity);
            RedDiscturn = true;
        }
    }
}

bool updateboardState(int column)
    {  
    for (int row = 0; row < heightOfBoard; row++ )
        {
        if (boardState[column,row] == 0) //Found empty spot
        {
            if(RedDiscturn)
            {
                boardState[column, row] = 1;
                }
                else
                {
                    boardState[column, row] = 2;
                }
                Debug.Log("Piece being spawned at (" + column + ", " + row + ")");
                return true;
            }
        }
        Debug.LogWarning("full");
        return false;
    }
}