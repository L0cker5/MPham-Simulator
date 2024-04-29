using TMPro;
using UnityEngine;

public class KeyboardManager : MonoBehaviour
{
    public static KeyboardManager instance;

    public TMP_InputField inputField;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

}
