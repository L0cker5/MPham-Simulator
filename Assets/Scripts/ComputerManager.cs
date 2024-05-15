using System;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
public class ComputerManager : MonoBehaviour
{
    public static ComputerManager instance;

    //[SerializeField] 
    public TMP_InputField patientName, quantity, strength,
        dose, frequency; 

    public TMP_Text medicationName, strengthUnit, medicationType, errorPatientName, errorQuantity, 
        errorStrength, errorDose, errorFrequency;

    private bool nameError = true;
    private bool quantityError = true;
    private bool strengthError = true;
    private bool doseError = true;
    private bool frequencyError = true;

    private float _strength;

    private int _quantity;

    private DateTime date;
    //TMP_InputField inputField;

    [SerializeField]
    GameObject label;
    
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

    // Update is called once per frame
    void Update()
    {

    }

    public void PrintLabel()
    {
        ResetErrorMessages();


    //    private bool _checkMedName = true;
    //private bool quantityError = true;
    //private bool _checkStrength = true;
    //private bool doseError = true;
    //private bool frequencyError = true;

        //errorDose.enabled = false;
        //errorFrequency.enabled = false;
        //errorPatientName.enabled = false;
        //errorQuantity.enabled = false;
        //errorStrength.enabled = false;

        nameError = CheckName(patientName.text);
        quantityError = CheckQuantity(quantity.text);
        strengthError = CheckStrength(strength.text);
        doseError = CheckDose(dose.text);
        frequencyError = CheckFrequency(frequency.text);

        if (nameError == false || quantityError == false || strengthError == false || doseError == false || frequencyError == false)
        {
        
        }
        else
        {
            date = DateTime.Now;
        
            Vector3 position = spawnPoint.position;
            Quaternion rotation = spawnPoint.rotation;

            Debug.Log("Float = " +  _strength);

            Debug.Log("Label Printed");

            LabelProperties labelProperties = label.GetComponent<LabelProperties>();
           
            labelProperties.PatientName = patientName.text.Trim();
            labelProperties.TodaysDate = date.ToString("dd-MM-yyyy");
            labelProperties.Quantity = _quantity;
            labelProperties.MedicationName = medicationName.text.Trim();
            labelProperties.Strength = _strength;
            Enum.TryParse(strengthUnit.text, out StrengthUnit unit);
            Debug.Log("Unit " + unit);
            labelProperties.StrengthUnit = unit;
            //StrengthUnitEnum(strengthUnit.text);
            Enum.TryParse(medicationType.text, out MedicationType type);
            labelProperties.MedicationType = type;
            labelProperties.Dosage = this.dose.text.Trim();
            labelProperties.Frequency = frequency.text.Trim();
            Instantiate(label, position, rotation);
            Debug.Log("Label Printed " + _strength);
        }


    }

    //private StrengthUnit StrengthUnitEnum(string text)
    //{
        
    //    if (Enum.TryParse<StrengthUnit>(text, true, out StrengthUnit unit)) {  return unit; }

    //    if (Enum.TryParse<StrengthUnit>(text, true, out StrengthUnit unit)) { return unit; }
        //bool 

        //switch (text)
        //{
        //    case "mL":
        //        return StrengthUnit.mL;
        //    case "kg":
        //        return StrengthUnit.kg;
        //    case "g":
        //        return StrengthUnit.g;
        //    case "mg":
        //        return StrengthUnit.mg;
        //    case "mcg":
        //        return StrengthUnit.mcg;
        //    case "ng":
        //        return StrengthUnit.ng;
        //    case "L":
        //        return StrengthUnit.L;

        //    default:
        //        break;
        //}
    //    return StrengthUnit.mg;
    //}

    private void ResetErrorMessages()
    {
        nameError = true;
        quantityError = true;
        strengthError = true;
        doseError = true;
        frequencyError = true;

        errorDose.enabled = false;
        errorFrequency.enabled = false;
        errorPatientName.enabled = false;
        errorQuantity.enabled = false;
        errorStrength.enabled = false;

    }   

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

    private bool CheckDose(string d)
    {
        Regex regex = new Regex(@"^[\p{L}]+$");
        //Regex regex = new Regex("/^[a-zA-Z&._-]+$/");
        //Regex regex = new Regex(@"^\d$");
        //Regex regex = new Regex([1 - 9] | [1 - 9][0 - 9] | [1 - 9][0 - 9][0 - 9] | 1000)
        //string value = d.Trim();

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

    private bool CheckStrength(string s)
    {
        //Regex regex = new Regex([1 - 9] | [1 - 9][0 - 9] | [1 - 9][0 - 9][0 - 9] | 1000)
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

    //public void PrintLabel()
    //{

    //    date = DateTime.Now;

    //    Vector3 position = spawnPoint.position;
    //    Quaternion rotation = spawnPoint.rotation;
    //    Debug.Log("Label Printed");
    //    LabelProperties labelProperties = label.GetComponent<LabelProperties>();
    //    labelProperties.PatientName = patientName.text;
    //    labelProperties.TodaysDate = date.ToString("dd-MM-yyyy");
    //    labelProperties.Quantity = quantity.text;
    //    labelProperties.MedicationName = medicationName.text;
    //    labelProperties.Strength = strength.text;
    //    labelProperties.StrengthUnit = strengthUnit.text;
    //    labelProperties.MedicationType = medicationType.text;
    //    labelProperties.Dosage = dose.text;
    //    labelProperties.Frequency = frequency.text;
    //    Instantiate(label, position, rotation);
    //    Debug.Log("Label Printed");

    //}

}
