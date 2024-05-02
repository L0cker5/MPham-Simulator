using UnityEngine;

public class ShelfTrigger : MonoBehaviour
{
    private readonly string box = "Box";
    private readonly string prescriptionMedication = "PrescriptionMedication";

    public GameObject meds;

    string boxMedicationName;
    int boxStrength;
    string labelPatientName, labelTodaysDate, labelMedicationName, labelQuantity, labelStrength,
    labelStrengthUnit, labelMedicationType, labelDoseage, labelFrequency;

    //string test = "test";

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.CompareTag(box))
        {
            BoxProperties boxProperties = other.GetComponentInParent<BoxProperties>();

            if (boxProperties.CompareTag(prescriptionMedication))
            {
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

                Debug.Log("Box Trigger Name: " + boxMedicationName + " Strength " + boxStrength);
                Debug.Log("Label Trigger Patient Name: " + labelPatientName + " Date: " + labelTodaysDate +
                " " + labelQuantity + " " + labelMedicationName + " " + labelStrength + " " + labelStrengthUnit
                + " " + labelMedicationType + " Take " + labelDoseage + " " + labelFrequency);
            }

        }

    }

    private void OnTriggerExit(Collider other)
    {

    }

}
