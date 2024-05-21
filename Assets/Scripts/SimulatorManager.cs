using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

/// <summary>
/// Manages the comparison of the prescription and the medication being dispensed and displays to the user 
/// if they have successfully or unsuccessfully dispoenced the prescripton
/// </summary>
public class SimulatorManager : MonoBehaviour
{
    // Access's the data stored in the trigger
    [SerializeField]
    private ShelfTrigger trigger;

    // Access's the data stored in the prescripton
    [SerializeField]
    private PrescriptionProperties pProps;

    // The text to be displayed to the user showing errors of if they have sussesfully dispenced a prescripton 
    public TMP_Text displayText;

    // A List of error messages to be displayed to the user if the have not dispensed the correct medication of if the label has errors
    private List<string> errorsList = new();

    // bool values to set if the various values on the prescription and medication to be dispensed match
    private bool _checkMedName = true; 
    private bool _checkStrength = true;
    private bool _checkPatientName = true;
    private bool _checkQuantity = true;
    private bool _checkStrengthUnit = true;
    private bool _checkMedicationType = true;
    private bool _checkDosage = true;
    private bool _checkFrequency = true;

    /// <summary>
    /// Attached to the "Prescripton Not Signed" button. If the button is pressed
    /// checks if the prescripton has been signed and displays the relevent 
    /// message to the user.
    /// </summary>
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

    /// <summary>
    /// Attached to the "Prescriptoon Out Of Date" button. If the button is
    /// pressed checks if the prescripton is within the required date range
    /// and displays the relevant message to the user
    /// </summary>
    public void ScriptOutOfDate() //true(1) = is out of _date
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

    /// <summary>
    /// Checks to see if there is a medication box sitting within the trigger area of the dispensing counter.
    /// If there is no medication within the trigger area displays the relevent message to the user.
    /// If true checks if the prescriptoin has been signed and is in date.
    /// </summary>
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

    /// <summary>
    /// Check is thats the prescription has been signed then if is in within valid date range.
    /// If either are false displays the relevent message to the user.
    /// If is signed and is in date preceeds to check the medication being dispensed matches
    /// what is on the prescription.
    /// </summary>
    /// <returns>true of false</returns>
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
            displayText.text = "The Prescription is out of _date and should not be dispensed.";
            displayText.enabled = true;
            return false;
        }
        else
        {
            CheckBoxAndLabel();
            return true;
        }
    }
    /// <summary>
    /// Checks if medication box name & strength match the label name & strength
    /// If returns false display the relevent error message to the user.
    /// If true proceed with checking the information on the medication box & prescription label. 
    /// </summary>
    /// <returns>true or false</returns>
    private bool CheckBoxAndLabel()
    {

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

    /// <summary>
    /// Checks that values stored on the prescripton label and medicaton box match what is on the prescription.
    /// If all return as true a "Well Done" message is dispaled to the user. If any return false the list of 
    /// errors is displayed to the user.
    /// </summary>
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
            displayText.text = "Well done, you have correctly dispensed the medication";
            displayText.color = Color.green;
            displayText.enabled = true;
        } else
        {
            displayText.text = String.Join("\n",errorsList);
            displayText.enabled = true;
        }
    }

    /// <summary>
    /// Check medication box name matches what is on the prescription
    /// </summary>
    /// <returns>true of false</returns>
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

    /// <summary>
    /// Checks if the medication box strength matches what is on the prescription
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Checks patient name on the prescription label matches what is on the prescription
    /// </summary>
    /// <returns>true or false</returns>
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

    /// <summary>
    /// Checks the quantity on the prescription label matches what is on the prescription
    /// </summary>
    /// <returns>true or false</returns>
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

    /// <summary>
    /// Checks the strength unit on the prescription label matches what is on the prescription 
    /// </summary>
    /// <returns>true or false</returns>
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

    /// <summary>
    /// Checks that the medication type on the prescription label mathces what is on the prescription
    /// </summary>
    /// <returns>true or false</returns>
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

    /// <summary>
    /// Checks the dosage on the prescription label matches what is on the prescription
    /// </summary>
    /// <returns>true or false</returns>
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

    /// <summary>
    /// Checks the frequency matches what is on the prescription. It first checks if what is 
    /// writen on the script matches an array of abbreviated frequencies if yes it checks that
    /// what has been been returned matches what is on the prescription label. If the prescription is not
    /// abbreviated then it checks the prescription label string against the prescription 
    /// </summary>
    /// <returns>true or false</returns>
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
                string error = "The prescription frequency does not match what you are trying to dispense.";
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
            string error = "The prescription frequency does not match what you are trying to dispense.";
            errorsList.Add(error);
            return false;
        }

        
    }

    /// <summary>
    /// Switch statement comparing prescription abbreviations
    /// </summary>
    /// <returns>string</returns>
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

    /// <summary>
    /// Switch statement comparing the sting returned for dose on the prescription label and converts
    /// it to the int value. It it doesnt match values 1-9 then it is not a valid number and is set too 0 
    /// </summary>
    /// <returns>int</returns>
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
}
