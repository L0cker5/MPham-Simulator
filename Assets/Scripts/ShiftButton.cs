using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ShiftButton : MonoBehaviour
{

    public static ShiftButton instance;

    public bool shifted = false;

    public void TypeShiftKey()
    {
        
        shifted = !shifted;
        
        Debug.Log("Shifted in Shift Button = " + shifted);

    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
