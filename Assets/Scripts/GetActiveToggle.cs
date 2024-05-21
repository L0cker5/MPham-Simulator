using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Attached to each toogle in a flat UI canvas used to select the Medication name, 
/// strength unit and medication type when printing a prescription label
/// </summary>
public class GetActiveToggle : MonoBehaviour
{
    [SerializeField]
    private Toggle _toggle;

    [SerializeField]
    private TMP_Text _toggleText;

    private readonly string _medicationNameTag = "Medication Name Toggle";
    private readonly string _strengthUnitTag = "Strength Unit Toggle";
    private readonly string _medicationTypeTag = "Medication Type Toggle";

    /// <summary>
    /// When a _toggle is changed for each of the three UI Canvas's it checks that the bool value of the toggel is set to ON
    /// and compares the tag attached to the _toggle setting the text value of the selected _toggle as the value stored on
    /// the prescription label and displayed when printed
    /// </summary>
    public void ToggleChanged()
    {
        
        if (_toggle.isOn && _toggle.CompareTag(_medicationNameTag)) 
        { 
        Debug.Log("Toggle Tag " + _toggleText.text + " active");
        
        ComputerManager.instance.medicationName = _toggleText;
        }
        else if (_toggle.isOn && _toggle.CompareTag(_strengthUnitTag))
        {
            Debug.Log("Toggle Tag " + _toggleText.text + " active");

            ComputerManager.instance.strengthUnit = _toggleText;
        }
        else if (_toggle.isOn && _toggle.CompareTag(_medicationTypeTag))
        {
            Debug.Log("Toggle Tag " + _toggleText.text + " active");

            ComputerManager.instance.medicationType = _toggleText;
        }
    }
}
