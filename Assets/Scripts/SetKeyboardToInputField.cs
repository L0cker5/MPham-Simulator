using TMPro;
using UnityEngine;

/// <summary>
/// Attached to each computer inputField. When selected sets this inputField to the current active text input in the KeyboardManager 
/// </summary>
public class SetKeyboardToInputFiled : MonoBehaviour
{
    private TMP_InputField input;

    public void SetKeyboardInput()
    {
        // Gets the TMP_InputField 
        input = GetComponentInChildren<TMP_InputField>();
        
        // Sets this as the active inputField and changes the background color to display the field as active
        input.ActivateInputField();
        
        // Sets the active inputField in the ComputerManager
        KeyboardManager.instance.inputField = input;

        //Debug.Log("Set Keyboard");
        
    }

}
