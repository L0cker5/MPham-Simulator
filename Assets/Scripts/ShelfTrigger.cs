using UnityEngine;

public class ShelfTrigger : MonoBehaviour
{
    private readonly string box = "Box";
    private readonly string prescriptionMedication = "PrescriptionMedication";

    public GameObject meds;

    string medsName;
    int medsStrength;
    string labelName;
    string labelFrequency;

    string test = "test";

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
                medsName = boxProperties.Name;
                medsStrength = boxProperties.Strength;
              
                LabelProperties labelProperties = boxProperties.GetComponentInChildren<LabelProperties>();

                labelName = labelProperties.MedicationName;
                labelFrequency = labelProperties.Frequency;
                
                Debug.Log("Label Trigger Name: " + medsName + " Strength " + medsStrength + ", Label: " + labelName + " " +labelFrequency);
            }

        }

    }

    private void OnTriggerExit(Collider other)
    {

    }

}
