using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using UnityEngine;

/// <summary>
/// This class will check if a GameObject with the tag "Label"
/// has been attached to the prescription _box. If it has the Label 
/// GameObject becomes a child of the Medication Box GameObject. 
/// It will then check the Medication Box GameObject tag and
/// update this to "PrescriptionMedication".
///
/// If the Label GameObject is removed from the Medication Box 
/// GameObject it is detach from the parent Medication Box GameObject
/// and the Medication Box GameObject tag is updated too "Medication".
/// </summary>
public class PrescriptionBoxTrigger : MonoBehaviour
{
    // A boolean indicating whether the _label is attached to something
    public bool lableIsAttached = false;
    // Parent object of the _box prefab
    public GameObject parentObject;
    // A reference to the prescription _label object
    public GameObject prescriptionLabel;

    //Grabbable labelGrabbable;

    // Tag names used for object comparison
    private readonly string _label = "Label";
    private readonly string _attachedLabel = "Attached Label";
    private readonly string _prescriptionMedication = "PrescriptionMedication";
    private readonly string _medication = "Medication";

    /// <summary>
    /// Called when a collider enters the trigger area.
    /// If the entering object has the tag "Label," it sets this object as 
    /// the prescriptionLabel gameObject and calls the MakeChild() method passing
    /// the prescriptionLabel and a value of "true".
    /// </summary>
    /// <param name="other">the object entering the trigger</param>

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(_label))
        {
            prescriptionLabel = other.gameObject;

            MakeChild(prescriptionLabel, true);
        }
    }

    /// <summary>
    /// Called when a collider exits the trigger area. 
    /// If the exiting object has the tag "Attached Label," it sets this object as 
    /// the prescriptionLabel gameObject and calls the DetachFromParent() method 
    /// passing the prescriptionLabel and a value of "false".
    /// </summary>
    /// <param name="other">the object exiting the trigger</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(_attachedLabel))
        {
            prescriptionLabel = other.gameObject;

            DetachFromParent(prescriptionLabel, false);
        }
    }

    /// <summary>
    /// Sets the prescriptionLabel gameObject as a child of the parent object 
    /// if b is true. updates the tag to "Attached Label" and enables the 
    /// Transfer On Second Selection check _box in the Gabbable on the prescriptionLabel 
    /// gameObject to prevent the _label from being able to have its scale altered when 
    /// attached to the _box.  
    /// </summary>
    /// <param name="pLabel">prescriptionLabel gameObject.</param>
    /// <param name="b">true or false.</param>
    private void MakeChild(GameObject pLabel, bool b)
    {
        lableIsAttached = b;

        if (lableIsAttached)
        {
            pLabel.transform.SetParent(parentObject.transform);
            
            pLabel.tag = _attachedLabel;
            
            pLabel.GetComponentInChildren<Grabbable>().TransferOnSecondSelection = true;
            UpdateTag(b);
        }
        else
        {
            pLabel.transform.SetParent(null);
        }
    }

    /// <summary>
    /// Detaches the prescriptionLabel gameObject from the parent object if b 
    /// is false.
    /// </summary>
    /// <param name="pLabel">prescriptionLabel gameObject.</param>
    /// <param name="b">true or false.</param>
    private void DetachFromParent(GameObject pLabel, bool b)
    {
        lableIsAttached = b;
        if (!lableIsAttached)
        {
            pLabel.transform.SetParent(null);
            pLabel.tag = _label;
            pLabel.GetComponentInChildren<Grabbable>().TransferOnSecondSelection = false;
            UpdateTag(b);
        }
    }

    /// <summary>
    /// Updates the tag of the parent object based on the boolean value f and its 
    /// current tag.
    /// </summary>
    /// <param name="f">true or false</param>
    private void UpdateTag(bool f)
    {
        // If the parent object is tagged as "Medication" and f == true,
        // it changes the parent object's tag to "PrescriptionMedication".
        if (parentObject.CompareTag(_medication) && (f == true))
        {
            parentObject.tag = _prescriptionMedication;
        }
        // If the parent object is tagged as "Medication" and f == false,
        // it keeps the parent object tagged as "Medication".
        else if (parentObject.CompareTag(_medication) && (f == false))
        {
            parentObject.tag = _medication;
        }
        // If the parent object is tagged as "PrescriptionMedication" and f == false,
        // it changes the parent object's tag to "Medication".
        else if (parentObject.CompareTag(_prescriptionMedication) && (f == false))
        {
            parentObject.tag = _medication;
        }
        // If the parent object is tagged as "PrescriptionMedication" and f == true,
        // it keeps the parent object tagged as "PrescriptionMedication". 
        else if (parentObject.CompareTag(_prescriptionMedication) && (f == true))
        {
            parentObject.tag = _prescriptionMedication;
        }
    }

}
