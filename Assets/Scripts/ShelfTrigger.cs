using UnityEngine;

/// <summary>
/// Detects when a medication box enters the trigger and reads its values 
/// </summary>
public class ShelfTrigger : MonoBehaviour
{
    private readonly string _box = "Box";
    private readonly string _prescriptionMedication = "PrescriptionMedication";

    public bool shelftriggered = false;

    public GameObject meds;

    public float boxStrength, labelStrength;
    
    public int labelQuantity;
    
    public string boxMedicationName, labelPatientName, labelTodaysDate, labelMedicationName, 
    labelDoseage, labelFrequency;

    public StrengthUnit labelStrengthUnit;
    public MedicationType labelMedicationType;

    /// <summary>
    /// When a GameObject enters the trigger area checks if it has the tag "box" if it does gets the Box Properties and checks 
    /// that the tag is "PrescriptionMedication", if the tags match it reads and stores the data from the box and label. 
    /// </summary>
    /// <param name="other">the object in the trigger area</param>
    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.CompareTag(_box))
        {
            BoxProperties boxProperties = other.GetComponentInParent<BoxProperties>();

            if (boxProperties.CompareTag(_prescriptionMedication))
            {
                shelftriggered = true;

                boxMedicationName = boxProperties.Name;
                boxStrength = boxProperties.Strength;
              
                LabelProperties labelProperties = boxProperties.GetComponentInChildren<LabelProperties>();

                labelPatientName = labelProperties.patientName;
                labelTodaysDate = labelProperties.TodaysDate;
                labelQuantity = labelProperties.Quantity;
                labelMedicationName = labelProperties.MedicationName;
                labelStrength = labelProperties.Strength;
                labelStrengthUnit = labelProperties.StrengthUnit;
                labelMedicationType = labelProperties.MedicationType;
                labelDoseage = labelProperties.Dosage;
                labelFrequency = labelProperties.Frequency;
            }

        }

    }

    /// <summary>
    /// When a GameObjects leaves the trigger area checks that it is tags match "box" and "PrescriptionMedication" 
    /// then resets the variables for the stored prescription information to default values.
    /// </summary>
    /// <param name="other">the object exiting the trigger area</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(_box))
        {
            BoxProperties boxProperties = other.GetComponentInParent<BoxProperties>();

            if (boxProperties.CompareTag(_prescriptionMedication))
            {
                shelftriggered = false;

                boxMedicationName = null;
                boxStrength = 0;
                labelPatientName = null;
                labelTodaysDate = null;
                labelQuantity = 0;
                labelMedicationName = null;
                labelStrength = 0;
                labelDoseage = null;
                labelFrequency = null;

                Debug.Log("Box Trigger Name: " + boxMedicationName + " Strength " + boxStrength);
                Debug.Log("Label Trigger Patient Name: " + labelPatientName + " Date: " + labelTodaysDate +
                " " + labelQuantity + " " + labelMedicationName + " " + labelStrength + " " + labelStrengthUnit
                + " " + labelMedicationType + " Take " + labelDoseage + " " + labelFrequency);
            }

        }
    }

}
