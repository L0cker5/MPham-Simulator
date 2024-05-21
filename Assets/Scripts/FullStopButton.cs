using TMPro;
using UnityEngine;

/// <summary>
/// Activated when the "." key is pressed on the keyboard
/// </summary>
public class FullStopButton : MonoBehaviour
{

    /// <summary>
    /// Adds a "." at the current position in the inputfield and moves the caret one positon 
    /// </summary>
    public void TypeFullStop()
    {
        TMP_InputField inputField = KeyboardManager.instance.inputField;

        inputField.text += ".";
        inputField.caretPosition++;
        //Debug.Log("Space Button Pressed");
    }
}

