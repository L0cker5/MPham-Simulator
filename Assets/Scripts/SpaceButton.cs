using TMPro;
using UnityEngine;

/// <summary>
/// Activated when the "space" key is pressed on the keyboard
/// 
/// </summary>
public class SpaceButton : MonoBehaviour
{
    /// <summary>
    /// Adds an empty space " " at the current position in the inputField and moves the caret one positon 
    /// </summary>
    public void TypeSpaceKey()
    {
        TMP_InputField inputField = KeyboardManager.instance.inputField;

        inputField.text += " ";
        inputField.caretPosition ++;
        //Debug.Log("Space Button Pressed");
    }
}
