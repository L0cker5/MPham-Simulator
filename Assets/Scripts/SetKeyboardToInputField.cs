using TMPro;
using UnityEngine;

public class SetKeyboardToInputFiled : MonoBehaviour
{
    private TMP_InputField input;

    public void SetKeyboardInput()
    {

        input = GetComponentInChildren<TMP_InputField>();
        
        input.ActivateInputField();
        
        KeyboardManager.instance.inputField = input;

        Debug.Log("Set Keyboard");
        
    }

}
