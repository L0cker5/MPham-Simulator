using System;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

/// <summary>
/// Connected to the inputfields and scrollable lists to be completed on the comupter screen so 
/// a prescription label can be printed 
/// </summary>
public class ComputerManager : MonoBehaviour
{
    public static ComputerManager instance;

    public TMP_InputField patientName, quantity, strength, dose, frequency; 

    public TMP_Text medicationName, strengthUnit, medicationType, errorPatientName, errorQuantity, 
        errorStrength, errorDose, errorFrequency;

    private bool _nameError = true;
    private bool _quantityError = true;
    private bool _strengthError = true;
    private bool _doseError = true;
    private bool _frequencyError = true;

    private float _strength;

    private int _quantity;

    private DateTime _date;

    [SerializeField]
    private GameObject label;
    
    [SerializeField] 
    private Transform spawnPoint;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        patientName.text = string.Empty;
        quantity.text = string.Empty;
        strength.text = string.Empty;
        dose.text = string.Empty;
        frequency.text = string.Empty;

        //Debug.Log("Error patient Name: " + patientName.text.Length);
    }

    /// <summary>
    /// Checks to ensure none of the inputfields have been left blank or have errors, if all come 
    /// back true the label is printed with the details. if errors are returned the corisponding 
    /// error messages are desplaed to the user for correction
    /// </summary>
    public void PrintLabel()
    {
        ResetErrorMessages();

        _nameError = CheckName(patientName.text.Trim());
        _quantityError = CheckQuantity(quantity.text.Trim());
        _strengthError = CheckStrength(strength.text.Trim());
        _doseError = CheckDose(dose.text.Trim());
        _frequencyError = CheckFrequency(frequency.text.Trim());

        if (!_nameError || !_quantityError || !_strengthError || !_doseError || !_frequencyError)
        {
        
        }
        else
        {
            _date = DateTime.Now;
        
            Vector3 position = spawnPoint.position;
            Quaternion rotation = spawnPoint.rotation;

            Debug.Log("Float = " +  _strength);

            Debug.Log("Label Printed");

            LabelProperties labelProperties = label.GetComponent<LabelProperties>();
           
            labelProperties.PatientName = patientName.text.Trim();
            labelProperties.TodaysDate = _date.ToString("dd-MM-yyyy");
            labelProperties.Quantity = _quantity;
            labelProperties.MedicationName = medicationName.text.Trim();
            labelProperties.Strength = _strength;
            Enum.TryParse(strengthUnit.text, out StrengthUnit unit);
            Debug.Log("Unit " + unit);
            labelProperties.StrengthUnit = unit;
            Enum.TryParse(medicationType.text, out MedicationType type);
            labelProperties.MedicationType = type;
            labelProperties.Dosage = this.dose.text.Trim();
            labelProperties.Frequency = frequency.text.Trim();
            Instantiate(label, position, rotation);
            Debug.Log("Label Printed " + _strength);
        }


    }

    /// <summary>
    /// Resets error booleans to true and clears all error messages.
    /// </summary>
    private void ResetErrorMessages()
    {

        errorDose.enabled = false;
        errorFrequency.enabled = false;
        errorPatientName.enabled = false;
        errorQuantity.enabled = false;
        errorStrength.enabled = false;

    }

    /// <summary>
    /// Returns false if input field is empty else returns true
    /// </summary>
    /// <param name="f">text input from the frequency inputfield</param>
    /// <returns>a boolean true or false</returns>
    private bool CheckFrequency(string f)
    {
        if (f.Length <= 0)
        {
            errorFrequency.enabled = true;
            errorFrequency.text = "Frequency cannot be left blank";
            return false;
        }
        else
        {
            return true;
        }
    }

    /// <summary>
    /// Returns false if input field is empty or contains numbers else returns true
    /// </summary>
    /// <param name="d">text input from the dose inputfield</param>
    /// <returns>a boolean true or false</returns>
    private bool CheckDose(string d)
    {
        Regex regex = new Regex(@"^[\p{L}]+$");

        Debug.Log("String Length: " + d.Length + " : " + d);

        if (d.Length <= 0)
        {
            errorDose.enabled = true;
            errorDose.text = "Dose cannot be left blank";
            return false;
        }
        else if (!regex.IsMatch(d))
        {
            errorDose.enabled = true;
            errorDose.text = "Please type the dosage as a word";
            return false;
        }
        else
        {
            return true;
        }
    }

    /// <summary>
    /// Returns false if input field is empty or not a number else returns true
    /// </summary>
    /// <param name="s">text input from the strength inputfield</param>
    /// <returns>a boolean true or false</returns>
    private bool CheckStrength(string s)
    {
        bool successfullyParsed = float.TryParse(s, out _strength);

        if (!successfullyParsed)
        {
            errorStrength.enabled = true;
            errorStrength.text = "Strength must be a number";
            return false;
        }
        else if ( _strength <= 0 || _strength > 10000)
        {
            errorStrength.enabled = true;
            errorStrength.text = "Strength must be more than 0 and less that 10000";
            return false;
        }
        else
        {
            return true;
        }
    }

    /// <summary>
    /// Returns false if input field is empty else returns true
    /// </summary>
    /// <param name="p">text input from the name inputfield</param>
    /// <returns>a boolean true or false</returns>
    private bool CheckName(string p)
    {
        if (p.Length <= 0)
        {
            errorPatientName.enabled = true;
            errorPatientName.text = "Name cannot be left blank";
            Debug.Log("Error there is no name" + p.Length);
            return false;
        }
        else
        {
            Debug.Log("Error there is a name " + p.Length + " |" + p + "|");
            return true;
        }
    }

    /// <summary>
    /// Returns false if input field is empty or not a number else returns true
    /// </summary>
    /// <param name="q">text input from the name inputfield</param>
    /// <returns>a boolean true or false</returns>
    private bool CheckQuantity(string q)
    {
        bool successfullyParsed = int.TryParse(q, out _quantity);

        if (!successfullyParsed)
        {
            errorQuantity.enabled = true;
            errorQuantity.text = "Quantity must be a number";
            return false;
        }
        else if (_quantity <= 0 || _quantity > 100)
        {
            errorQuantity.enabled = true;
            errorQuantity.text = "Quantity must be more than 0 and less that 100";
            return false;
        }
        else
        {
            return true;
        }
    }

}
