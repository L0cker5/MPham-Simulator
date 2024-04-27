using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardButton : MonoBehaviour
{
    public string character;
    public string shiftCharacter;

    public TextMeshProUGUI keyLabel;

    //private Button thisKey;

    private bool isShifted = false;

    public void Update()
    {
        //KeyboardManager.instance.shiftButton.onClick.AddListener(HandleShift);
        isShifted = ShiftButton.instance.shifted;
        //HandleShift();
        Debug.Log("Shifted in Keyboard Button = " + isShifted);
        //thisKey=GetComponent<Button>();
        //thisKey.onClick.AddListener(TypeKey);
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
        
    }

    private void HandleShift()
    {
        
        //isShifted = !isShifted;

        if (isShifted == true)
        {
            keyLabel.text = shiftCharacter;
        }
        else
        {
            keyLabel.text = character;
        }
        //Debug.Log("Shifted in Keyboard= " + isShifted);
    }
}
