using System;
using UnityEngine;

public class ShiftButton : MonoBehaviour
{

    public static ShiftButton instance;

    public bool shifted = false;
    
    public event Action OnActonEvent;
    
    
    private void Awake()
    {

        //Debug.Log("Shifted in Shift Button Awake = " + shifted);

        if (instance == null)
        {
            instance = this;
        }
    }

    public void TypeShiftKey()
    {
        OnActonEvent?.Invoke();

        //Debug.Log("Shifted in Shift Button TypeShiftKey = " + shifted);
    }


}
