using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class SimulatorManager : MonoBehaviour
{

    [SerializeField]
    private ShelfTrigger trigger;

    [SerializeField]
    private PrescriptionProperties pProps;

    public TMP_Text displayText;

    private List<string> errorsList = new();

    private bool matchBoxAndLabel = true;
    private bool _checkMedName = true; 
    private bool _checkStrength = true;
    private bool _checkPatientName = true;
    private bool _checkQuantity = true;
    private bool _checkStrengthUnit = true;
    private bool _checkMedicationType = true;
    private bool _checkDosage = true;
    private bool _checkFrequency = true;


    void Awake()
    {


    }

    // Start is called before the first frame update
    void Start()
    {
        //prescription = pProps.prescription.;
        //prescription.PrintMedicationToScript();
        Debug.Log("Length of Mediaction Name: " + pProps.prescription.MedicationName + " Length: " + pProps.prescription.MedicationName.Length);

    }

    public void ScriptNotSigned()
    {
        if ( pProps.prescription.IsSigned) //true(1) = is signed
        {
            displayText.text = "No Sorry this script is signed";
            displayText.enabled = true;
        }
        else
        {
            displayText.text = "Correct the script is not signed";
            displayText.color = Color.green;
            displayText.enabled = true;

        }
    }

    public void ScriptOutOfDate() //true(1) = is out of date
    {
        if (pProps.prescription.IsOutOfDate)
        {
            displayText.text = "Correct the script is out of date";
            displayText.color = Color.green;
            displayText.enabled = true;
        }
        else
        {
            displayText.text = "No sorry this script is in date";
            displayText.enabled = true;
        }
    }

    public void CheckTriggerActive()
    {
        displayText.enabled = false;
        displayText.color = Color.red;
        errorsList.Clear();

        //ShelfTrigger trigger2 = new ShelfTrigger();
        string boxName = trigger.boxMedicationName;
        
        
        if (trigger.shelftriggered == true)
        {
        Debug.Log("Length of Trigger Name: " + trigger.boxMedicationName + " Length: " + trigger.boxMedicationName.Length);
            CheckSignedAndDate();
        } 
        else
        {
            displayText.text = "No prescribable prescription has been dispensed, " +
                "please check the label has been attached to the prescription box " +
                "and it has been placed in the dispensing area."; 
            displayText.enabled = true;
            Debug.Log("The box name is: " + boxName);
        }
    }

    // Check is script signed then if is in date
    private bool CheckSignedAndDate()
    {
        if (!pProps.prescription.IsSigned) //==false
        {
            displayText.text = "The Prescription has not be signed by the doctor and should not be dispensed.";
            displayText.enabled = true;
            return false;
        }
        else if (pProps.prescription.IsOutOfDate) //== true
        {
            displayText.text = "The Prescription is out of date and should not be dispensed.";
            displayText.enabled = true;
            return false;
        }
        else
        {
            CheckBoxAndLabel();
            return true;
        }
    }
    // Check if box strength & name match label strength & name
    private bool CheckBoxAndLabel()
    {
        //float.TryParse(trigger.labelStrength, out float labelStrength);

        if (trigger.boxStrength != trigger.labelStrength)
        {
            displayText.text = "The strength on the label does not match the strength on the box";
            displayText.enabled = true;
            return false;
        }
        else if (trigger.boxMedicationName != trigger.labelMedicationName) 
        {
            displayText.text = "The name on the label does not match the name on the box";
            displayText.enabled = true;
            return false;
        }
        else
        {
            CheckPrescription();
            return true;
        }

    }

    // Proceed to check rest of the prescription
    private void CheckPrescription()
    {
        _checkMedName = CheckMedicationBoxName();
        _checkStrength = CheckMedicationBoxStrength();
        _checkPatientName = CheckPatientName();
        _checkQuantity = CheckQuantity();
        _checkStrengthUnit = CheckStrengthUnit();
        _checkMedicationType = CheckMedicationType();
        _checkDosage = CheckDosage();
        _checkFrequency = CheckFrequency();

        if (_checkMedName && _checkStrength && _checkPatientName && _checkQuantity && _checkStrengthUnit && _checkMedicationType && _checkDosage && _checkFrequency) 
        {
            displayText.text = "Well done";
            displayText.color = Color.green;
            displayText.enabled = true;
        } else
        {
            displayText.text = String.Join("\n",errorsList);
            displayText.enabled = true;
        }
    }

    // Check medication box name match what is on the prescription
    private bool CheckMedicationBoxName()
    {
        if (String.Equals(trigger.boxMedicationName, pProps.prescription.MedicationName))
        {
            return true;
        }
        else
        {
            string error = "The prescription name does not match what you are trying to dispense.";
            errorsList.Add(error);
            return false;
        }
    }

    // Check if the medication box strength matches what is on the prescription
    private bool CheckMedicationBoxStrength()
    {
        if (trigger.boxStrength == pProps.prescription.Strength)
        {
            return true;
        } 
        else
        {
            string error = "The prescription strength does not match what you are trying to dispense.";
            errorsList.Add(error);
            return false;
        }
    }

    // Check patient name on label matches what is on the prescription
    private bool CheckPatientName()
    {
        if (trigger.labelPatientName.Equals(pProps.patient.Name, StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }
        else
        {
            string error = "The name on the prescription does not match what is on the label you are trying to dispense.";
            errorsList.Add(error);
            return false;
        }
    }

    // Checks the quantity on the label matches what is on the prescription
    private bool CheckQuantity()
    {
        if (trigger.labelQuantity == pProps.prescription.Quantity)
        {
            return true;
        }
        else
        {
            string error = "The prescription quantity does not match what you are trying to dispense.";
            errorsList.Add(error);
            return false;
        }
    }

    // Checks the strength unit matches what is on the prescription 
    private bool CheckStrengthUnit()
    {
        if (trigger.labelStrengthUnit == pProps.prescription.StrengthUnit)
        {
            return true;
        }
        else
        {
            string error = "The prescription strength unit does not match what you are trying to dispense.";
            errorsList.Add(error);
            return false;
        }
    }

    // Checks that the medication type mathces what is on the prescription
    private bool CheckMedicationType()
    {
        if (trigger.labelMedicationType == pProps.prescription.MedicationType)
        {
            return true;
        }
        else
        {
            string error = "The prescription type does not match what you are trying to dispense.";
            errorsList.Add(error);
            return false;
        }
    }

    // Checks the dosage matches what is on the prescription
    private bool CheckDosage()
    {
        int doseAsInt = ConvertDosage();
        
        if (doseAsInt == pProps.prescription.ExpectedDose)
        {
            return true;
        }
        else
        {
            string error = "The prescription dosage does not match what you are trying to dispense.";
            errorsList.Add(error);
            return false;
        }
    }

    // Checks the frequency matches what is on the prescription. It first checks if what is 
    // writen on the script matches an array of abbreviated frequencies if yes it check that
    // what has been been returned matches what is on the label. If the prescription is not
    // abbreviated then it check the label string against the prescription string 
    private bool CheckFrequency()
    {
        bool freqAbbreviations = new[] {"od", "om", "nocte" }.Contains(pProps.prescription.DosingFrequency);

        if (freqAbbreviations)
        {
            string convertedAbbreviation = ConvertFrequency();

            if (convertedAbbreviation.Equals(trigger.labelFrequency, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else
            {
                string error = "The prescription frequency does not match what you are trying to dispense.1";
                //Debug.LogError("Frequency error converted text: " + convertedAbbreviation + " " + convertedAbbreviation.Length + 
                //    " " + " Label: " + trigger.labelFrequency + " " + trigger.labelFrequency.Length);
                errorsList.Add(error);
                return false;
            }
        }
        else if (pProps.prescription.DosingFrequency.Equals(trigger.labelFrequency, StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }
        else
        {
            string error = "The prescription frequency does not match what you are trying to dispense.2";
            errorsList.Add(error);
            return false;
        }

        
    }

    // switch statement comparing prescription abbreviations
    private string ConvertFrequency()
    {
        switch (pProps.prescription.DosingFrequency)
        {
            case "od":
                return "every day";
            case "om":
                return "every morning";
            case "nocte":
                return "at night";
            default:
                break;
        }
        return "";
    }

    // switch statement comparing the sting returned for dose on the prescription label and converts
    // it to the int value. It it doesnt match values 1-9 then it is not a valid number and set it too 0 
    private int ConvertDosage()
    {
        switch (trigger.labelDoseage.ToLower())
        {
            case "one":
                 return 1;
            case "two":
                return 2;
            case "three":
                return 3;
            case "four":
                return 4;
            case "five":
                return 5;
            case "six":
                return 6;
            case "seven":
                return 7;
            case "eigth":
                return 8;
            case "nine":
                return 9;
            default:
                break;
        }
        return 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
