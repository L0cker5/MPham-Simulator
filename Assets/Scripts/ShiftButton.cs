using System;
using UnityEngine;

/// <summary>
/// Activated when the shift key is pressed on the keyboard
/// </summary>
public class ShiftButton : MonoBehaviour
{
    
    public event Action OnActonEvent;
    
    /// <summary>
    /// When shift button is pressed ONActionEven is invoked changing the character 
    /// displayed on the keyboard to upper or lower case or special character. 
    /// </summary>
    public void TypeShiftKey()
    {
        OnActonEvent?.Invoke();
    }


}
