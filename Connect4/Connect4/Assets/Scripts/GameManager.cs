using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public string debugStartMessage;

    public GameObject RedDisc;
    public GameObject YellowDisc;

    public GameObject player1ghost;
    public GameObject player2ghost;

    public int heightOfBoard = 6;
    public int lengthOfBoard = 7;

    public GameObject[] spawnLoc;

    GameObject fallingPiece;
    bool RedDiscturn = true;

    int[,] boardState; //0 is empty , 1 is RedDisc , 2 is YellowDisc


    
    void Start()
    {
        //Debug.Log(debugStartMessage);
        //Debug.LogError("Error");
       // Debug.LogWarning("Warning");
    
        boardState = new int[lengthOfBoard, heightOfBoard];
        
        player1ghost.SetActive(false);
        player2ghost.SetActive(false);
    }

    public void HoverColumn(int column)
    {
        if (boardState[column, heightOfBoard-1]==0 && fallingPiece == null ||   fallingPiece.GetComponent<Rigidbody>().velocity == Vector3.zero)
        {
            if (RedDiscturn)
            {
                player1ghost.SetActive(true);
                player1ghost.transform.position = spawnLoc[column].transform.position;
            }
            else
            {
                player2ghost.SetActive(true);
                player2ghost.transform.position = spawnLoc[column].transform.position;
            }            
        }
    }

    public void SelectColumn(int column)
    {
        if (fallingPiece == null ||   fallingPiece.GetComponent<Rigidbody>().velocity == Vector3.zero)
        {
        //Debug.Log("GameManager Column" + column );
            TakeTurn(column);
        }
        }

    void TakeTurn(int column)
    {   
        if (updateboardState(column))
        {
            player1ghost.SetActive(false);
            player2ghost.SetActive(false);

            if (RedDiscturn)
            {
                fallingPiece = Instantiate(RedDisc,spawnLoc[column].transform.position,Quaternion.identity);
                fallingPiece.GetComponent<Rigidbody>().velocity = new Vector3(0, 0.1f,0);
                RedDiscturn = false;
                if (DidWin(1))
                {
                    Debug.LogWarning("Player 1  Won!");
                }
            }
            else
            {
                fallingPiece = Instantiate(YellowDisc,spawnLoc[column].transform.position,Quaternion.identity);
                fallingPiece.GetComponent<Rigidbody>().velocity = new Vector3(0, 0.1f,0);
                RedDiscturn = true;
                if (DidWin(2))
                {
                    Debug.LogWarning("Player 2  Won!");
                }
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

    bool DidWin(int playerNum)
    {
        //Horizontal
        for (int x = 0; x < lengthOfBoard -3; x++)
        {
            for (int y = 0; y < heightOfBoard; y++)
            {
                if (boardState [x+0, y] == playerNum && boardState[x+1, y] == playerNum && boardState[x+ 2, y] == playerNum && boardState[x+ 3, y] == playerNum)
                {
                    return true;
                }
            }
        }
        //Vertical
        for (int x =0; x < lengthOfBoard; x++)
        {
            for (int y =0; y < heightOfBoard -3; y++)
            {
                if (boardState[x,y] == playerNum && boardState[x, y + 1] == playerNum && boardState[x, y + 2] == playerNum && boardState[x, y + 3] == playerNum)
                {
                    return true;
                }
            }
        }
        //Diagonal Right
        for (int x =0; x < lengthOfBoard; x++)
        {
            for (int y =0; y < heightOfBoard -3; y++)
            {
                if (boardState[x,y] == playerNum && boardState[x + 1, y + 1] == playerNum && boardState[x + 2, y + 2] == playerNum && boardState[x + 3, y + 3] == playerNum)
                {
                    return true;
                }
            }
        }
        //Diagonal Left
        for (int x =0; x < lengthOfBoard; x++)
        {
            for (int y =0; y < heightOfBoard -3; y++)
            {
                if (boardState[x,y + 3] == playerNum && boardState[x + 1, y + 2] == playerNum && boardState[x + 2, y + 1] == playerNum && boardState[x + 3, y] == playerNum)
                {
                    return true;
                }
            }
        }
            return false;
    }
}









