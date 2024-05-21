using TMPro;
using UnityEngine;

/// <summary>
/// Sets the upper and lower case charaters on the keyboard for each key. Checks if the shift
/// button has been pressed to facilitate the change from upper to lower case.
/// </summary>
public class KeyboardButton : MonoBehaviour
{
    // lower case character
    public string character;
    // upper case character
    public string shiftCharacter;

    // the text field on the button to display the character
    public TextMeshProUGUI keyLabel;
    
    // the Shift key for the keyboard
    public GameObject shiftKey;

    // bool to check if the shift key has been pressed
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

    /// <summary>
    /// If the key is a number when the shift button is pressed display the corrisponding special character
    /// </summary>
    /// <returns>string</returns>
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


    /// <summary>
    /// OnActionEvent called when the shift button is pressed
    /// </summary>
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

    /// <summary>
    /// When the key is pressed checks if isShifted is true or false and adds the relevent text to the 
    /// inputfield and moves the caret one positon
    /// </summary>
    public void TypeKey()
    {
        
        if (isShifted == true)
        {
            KeyboardManager.instance.inputField.text += shiftCharacter;
            KeyboardManager.instance.inputField.caretPosition ++;
        }
        else
        {
            KeyboardManager.instance.inputField.text += character;
            KeyboardManager.instance.inputField.caretPosition ++;
        }

        Debug.Log("Shifted in Keyboard TypeKey = " + isShifted);
    }

}
