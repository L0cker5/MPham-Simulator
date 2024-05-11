using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FullStopButton : MonoBehaviour
{
    public void TypeFullStop()
    {
        TMP_InputField inputField = KeyboardManager.instance.inputField;

        inputField.text += ".";
        inputField.caretPosition++;
        //Debug.Log("Space Button Pressed");
    }
}

