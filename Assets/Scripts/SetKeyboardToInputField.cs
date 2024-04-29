using TMPro;
using UnityEngine;

public class SetKeyboardToInputFiled : MonoBehaviour
{
    
    public void SetKeyboardInput()
    {
        KeyboardManager.instance.inputField = GetComponentInChildren<TMP_InputField>();


        Debug.Log("Set Keyboard");

    }

}
