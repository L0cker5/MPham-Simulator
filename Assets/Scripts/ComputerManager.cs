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


    //    private bool nameError = true;
    //private bool quantityError = true;
    //private bool strengthError = true;
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
        

        float.TryParse(strength.text, out float st);
        Debug.Log("Float = " +  st);

        Vector3 position = spawnPoint.position;
        Quaternion rotation = spawnPoint.rotation;
        Debug.Log("Label Printed");
        LabelProperties labelProperties = label.GetComponent<LabelProperties>();
        labelProperties.PatientName = patientName.text;
        labelProperties.TodaysDate = date.ToString("dd-MM-yyyy");
        labelProperties.Quantity = quantity.text;
        labelProperties.MedicationName = medicationName.text;
        labelProperties.Strength = st;
        labelProperties.StrengthUnit = strengthUnit.text;
        labelProperties.MedicationType = medicationType.text;
        labelProperties.Dosage = this.dose.text;
        labelProperties.Frequency = frequency.text;
        Instantiate(label, position, rotation);
        Debug.Log("Label Printed " + st);
        }


    }

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
        if (s.Length <= 0)
        {
            errorStrength.enabled = true;
            errorStrength.text = "Strength cannot be left blank";
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
        if (q.Length <= 0)
        {
            errorQuantity.enabled = true;
            errorQuantity.text = "Quantity cannot be left blank";
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
