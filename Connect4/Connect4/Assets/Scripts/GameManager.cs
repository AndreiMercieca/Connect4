using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string debugStartMessage;

    public GameObject RedDisc;
    public GameObject YellowDisc;

    public void SelectColumn(object column)
    {
        throw new NotImplementedException("Edit mode support not implemented yet.");
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

    public void SelectColoumn(int column)
    {
    Debug.Log("GameManager Column" + column );
    }

    void TakeTurn(int column)
    {
        Instantiate(RedDisc,spawnLoc[column].transform.position,Quaternion.identity);
    }
}
