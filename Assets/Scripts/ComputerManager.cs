using System;
using TMPro;
using UnityEngine;
public class ComputerManager : MonoBehaviour
{
    public static ComputerManager instance;
    
    //[SerializeField] 
    public TMP_Text patientName, quantity, medicationName, strength, strengthUnit, medicationType, 
        dose, frequency, errorPatientName, errorQuantity, errorStrength, errorDose, errorFrequency;

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
        bool nameError = true;
        bool quantityError = true;
        bool strengthError = true;
        bool doseError = true;
        bool frequencyError = true;

        errorDose.enabled = false;
        errorFrequency.enabled = false;
        errorPatientName.enabled = false;
        errorQuantity.enabled = false;
        errorStrength.enabled = false;

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
        Debug.Log("Label Printed");
        LabelProperties labelProperties = label.GetComponent<LabelProperties>();
        labelProperties.PatientName = patientName.text;
        labelProperties.TodaysDate = date.ToString("dd-MM-yyyy");
        labelProperties.Quantity = quantity.text;
        labelProperties.MedicationName = medicationName.text;
        labelProperties.Strength = strength.text;
        labelProperties.StrengthUnit = strengthUnit.text;
        labelProperties.MedicationType = medicationType.text;
        labelProperties.Dosage = this.dose.text;
        labelProperties.Frequency = frequency.text;
        Instantiate(label, position, rotation);
        Debug.Log("Label Printed");
        }


    }

    private bool CheckFrequency(string f)
    {
        if (f.Length <= 1)
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
        if (d.Length <= 1)
        {
            errorDose.enabled = true;
            errorDose.text = "Dose cannot be left blank";
            return false;
        }
        else
        {
            return true;
        }
    }

    private bool CheckStrength(string s)
    {
        if (s.Length <= 1)
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
        if (p.Length <= 1)
        {
            errorPatientName.enabled = true;
            errorPatientName.text = "Name cannot be left blank";
            Debug.Log("Error there is no name");
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
        if (q.Length <= 1)
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
