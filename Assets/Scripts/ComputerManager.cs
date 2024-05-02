using System;
using TMPro;
using UnityEngine;
public class ComputerManager : MonoBehaviour
{
    public static ComputerManager instance;
    
    //[SerializeField] 
    public TMP_Text patientName, quantity, medicationName, strength, 
    strengthUnit, medicationType, doseage, frequency;

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
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PrintLabel()
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
        labelProperties.Dosage = doseage.text;
        labelProperties.Frequency = frequency.text;
        Instantiate(label, position, rotation);
        Debug.Log("Label Printed");

    }

}
