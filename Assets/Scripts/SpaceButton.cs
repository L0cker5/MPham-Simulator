using TMPro;
using UnityEngine;

public class SpaceButton : MonoBehaviour
{
    public void TypeSpaceKey()
    {
        TMP_InputField inputField = KeyboardManager.instance.inputField;

        inputField.text += " ";
        inputField.caretPosition ++;
        //Debug.Log("Space Button Pressed");
    }
}
