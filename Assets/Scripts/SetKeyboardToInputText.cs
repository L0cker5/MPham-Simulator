using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
using System;

public class SetKeyboardToInputText : MonoBehaviour
{
    //[SerializeField]
    //public InputField KInputField;

    public void SetKeyboardInput()
    {
        //TextMeshProVirtualKeyboardInputSource.instance.inputField = GetComponent<InputField>();
        
        //virtualKeyboard = OVRVirtualKeyboard.FindObjectOfType<OVRVirtualKeyboard>();

        //virtualKeyboard = GetComponent<OVRVirtualKeyboard>();

        //if (virtualKeyboard != null )
        //{
        //    Debug.Log("No Keyboard");
        //}
        //InputField inputField = null;

        //if (inputField = null)
        //{
        //    Debug.Log("No Keyboard InputField");
        //}

        //inputField = virtualKeyboard.GetComponent<InputField>().in = KInputField;


        Debug.Log("Set Keyboard");

        //var scriptAttached = virtualKeyboard.GetComponent<OVRVirtualKeyboardInputFieldTextHandler>();

        //Debug.Log("Set Keyboard");
        //scriptAttached.InputField = KInputField;
        //OVRVirtualKeyboardInputFieldTextHandler m_InputHandler;

        //m_InputHandler.inputField = inputField;


        //= virtualKeyboard.TryGetComponent<OVRVirtualKeyboardInputFieldTextHandler>;
    }

}
