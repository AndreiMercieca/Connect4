using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputField : MonoBehaviour
{
    public int coloumn;

    public GameManager gm;

    void OnMouseDown()
    {
        Debug.Log("Coloumn number is " + coloumn);
    }
}

