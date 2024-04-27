using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyboardManager : MonoBehaviour
{
    public static KeyboardManager instance;

    //public Button shiftButton;

    public TMP_InputField inputField;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

}
