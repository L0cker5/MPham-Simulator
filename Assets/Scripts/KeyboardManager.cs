using TMPro;
using UnityEngine;

/// <summary>
/// Sets the InputField the keyboard is entering text too
/// </summary>
public class KeyboardManager : MonoBehaviour
{
    // Singleton to ensure only one insance of KeyboardManger exists to recieve the current active inputField
    public static KeyboardManager instance;

    // The active InputField, this will change when the user selects a different InputFiled
    public TMP_InputField inputField;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

}
