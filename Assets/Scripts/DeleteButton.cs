using TMPro;
using UnityEngine;

public class DeleteButton : MonoBehaviour
{

    public void TypeDeleteKey()
    {
        TMP_InputField inputField = KeyboardManager.instance.inputField;

        
        int length = inputField.text.Length  - 1;
        if (length >= 0 )
        inputField.text = inputField.text.Substring(0, length);

        //Debug.Log("Delete Button Pressed");
    }
}
