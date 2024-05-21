using TMPro;
using UnityEngine;

/// <summary>
/// Connected to the Delete button on the keyboard prefab
/// </summary>
public class DeleteButton : MonoBehaviour
{
    /// <summary>
    /// Activiated when the delete button is pressed on the keyboard
    /// access's the currently active inputField and deletes a charater  
    /// </summary>
    public void TypeDeleteKey()
    {
        // Gets the current active inputFiled from the KeyboardManager
        TMP_InputField inputField = KeyboardManager.instance.inputField;
        
        int length = inputField.text.Length  - 1;
        // Check if there's any text to delete
        if (length >= 0 )
            // Remove the last character from the text
            inputField.text = inputField.text.Substring(0, length);

        //Debug.Log("Delete Button Pressed");
    }
}
