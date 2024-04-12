using UnityEngine;

/*
 * This class will check if a GameObject with the tag "Label"
 * has been attached to the medication box. If it has the Label 
 * GameObject becomes a child of the Medication Box GameObject. 
 * It will then check the Medication Box GameObject tag and
 * update this to "PrescriptionMedication".
 * 
 * If the Label GameObject is removed from the Medication Box 
 * GameObject it is detach from the parent Medication Box GameObject
 * and the Medication Box GameObject tag is updated too "Medication".
 */
public class MedicationBox : MonoBehaviour
{
    public bool lableIsAttached = false;

    public GameObject parentObject;
    GameObject prescriptionLabel;

    private readonly string label = "Label";
    private readonly string prescriptionMedication = "PrescriptionMedication";
    private readonly string medication = "Medication";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(label))
        {
            // assign parent object to component
            prescriptionLabel = other.gameObject;

            MakeChild(prescriptionLabel,true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(label))
        {
            prescriptionLabel = other.gameObject;

            DetachFromParent(prescriptionLabel,false);
        }
    }

    private void MakeChild(GameObject pLabel, bool b)
    {
        lableIsAttached = b;
        if (lableIsAttached)
        {
            pLabel.transform.SetParent(parentObject.transform);
            UpdateTag();
        }
        else
        {
            pLabel.transform.SetParent(null);
        }
    }

    private void DetachFromParent(GameObject pLabel, bool b)
    {
        lableIsAttached = b;
        if (!lableIsAttached)
        {
            pLabel.transform.SetParent(null);
            UpdateTag();
        }
    }

    private void UpdateTag()
    {
        if (parentObject.CompareTag(medication))
        {
            parentObject.tag = prescriptionMedication;
        } else if (parentObject.CompareTag(prescriptionMedication))
        {
            parentObject.tag = medication;
        }
    }

}
