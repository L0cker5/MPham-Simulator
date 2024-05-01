using TMPro;
using UnityEngine;

public class KeyboardButton : MonoBehaviour
{
    public string character;
    public string shiftCharacter;

    public TextMeshProUGUI keyLabel;

    public GameObject shiftKey;

    public bool isShifted = false;

    public void Awake()
    {
        //Debug.Log("Shifted in Keyboard Button Awake 1 = " + isShifted);

        // get character from the text input field of the button assiging it to the 'character variable'
        character = keyLabel.text;
        // & assigning its uppercase character to 'shiftCharacter'
        shiftCharacter = keyLabel.text.ToUpper();

        ShiftButton shiftButton = shiftKey.GetComponent<ShiftButton>();
        shiftButton.OnActonEvent += ShiftButton_OnActonEvent;

        //Debug.Log("Shifted in Keyboard Button Awake 2 = " + isShifted);
        string numbers = "1234567890";
        
        if (numbers.Contains(keyLabel.text))
        {
            shiftCharacter = GetShiftCharacter();
        }
    }

    private string GetShiftCharacter()
    {
        switch (keyLabel.text)
        {
            case "1":
                return "!";
            case "2":
                return "@";
            case "3":
                return "£";
            case "4":
                return "$";
            case "5":
                return "%";
            case "6":
                return "^";
            case "7":
                return "&";
            case "8":
                return "*";
            case "9":
                return "(";
            case "0":
                return ")";
            default:
                break;
        }
        return string.Empty;
    }

    private void ShiftButton_OnActonEvent()
    {
        isShifted = !isShifted;
        
        if (isShifted == true)
        {
            keyLabel.text = shiftCharacter;
        }
        else
        {
            keyLabel.text = character;
        }

        Debug.Log("Shifted in Button OnActionEvent = " + isShifted);
    }

    public void TypeKey()
    {
        if (isShifted == true)
        {
            KeyboardManager.instance.inputField.text += shiftCharacter;
        }
        else
        {
            KeyboardManager.instance.inputField.text += character;
        }

        Debug.Log("Shifted in Keyboard TypeKey = " + isShifted);
    }

}
