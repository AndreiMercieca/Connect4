using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string debugStartMessage;

    public GameObject RedDisc;
    public GameObject YellowDisc;

    internal void SelectColumn(object column)
    {
        throw new NotImplementedException();
    }

    public GameObject[] spawnLoc;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(debugStartMessage);
        Debug.LogError("Error");
        Debug.LogWarning("Warning");
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void SelectColoumn(int coloumn)
    {
    Debug.Log("GameManager Coloumn" + coloumn );
    }

    void TakeTurn(int coloumn)
    {
        Instantiate(RedDisc,spawnLoc[coloumn].transform.position,Quaternion.identity);
    }
}