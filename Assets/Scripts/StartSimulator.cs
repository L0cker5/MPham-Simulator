using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Xml.Linq;
using System.Linq;

public class StartSimulator : MonoBehaviour
{

    [SerializeField]
    private ShelfTrigger trigger;

    public TMP_Text errorMsgs;

    private List<Medication> medicationData;
    private List<Patient> patientData;
    private List<Doctor> doctorData;

    private List<string> errors;

    private bool matchBoxAndLabel = true;
    private bool nameError = true; 
    private bool strengthError = true;
    //private System.Random rand = new System.Random();

    //PrescriptionProperties pProps = new PrescriptionProperties();

    public Medication medication;
    public Patient patient;
    public Doctor doctor;

    private void Awake()
    {
        //GameObject trigger = GameObject.Find("ShelfObject");

        //var obj = trigger.GetComponentInChildren<ShelfTrigger>();
        

        //get the lists of medication, patient & doctor data
        medicationData = ReadCSV.readMedicationData();
        patientData = ReadCSV.readPatientData();
        doctorData = ReadCSV.readDoctorData();

        //call the methods to get a random medication, patient & doctor for the lists
        medication = getRandomMedication(medicationData);
        patient = getRandomPatient(patientData);
        doctor = getRandomDoctor(doctorData);

        string med = medication.PrintMedicationToScript();
        Debug.Log("Random:\n" + med);
        Debug.Log("Random Medication: " + medication.MedicationName + " " + medication.Strength + " " + medication.StrengthUnit + " " + medication.MedicationType + " BNF: " + medication.BnfLabels);
        Debug.Log("Random Patient: " + patient.Name + " DOB: " + patient.DateOfBirth);
        Debug.Log("Random Doctor:  " + doctor.Name + " " + doctor.Postcode);


    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void CheckTriggerActive()
    {
        errorMsgs.enabled = false;
        //ShelfTrigger trigger2 = new ShelfTrigger();
        string boxName = trigger.boxMedicationName;
        
        if (trigger.shelftriggered == true)
        {
            CheckBoxAndLabel();
        } 
        else
        {
            errorMsgs.text = "No prescribable medication has been dispensed, " +
                "please check the label has been attached to the medication box " +
                "and it has been placed in the dispensing area."; 
            errorMsgs.enabled = true;
            Debug.Log("The box name is: " + boxName);
        }
    }

    private bool CheckBoxAndLabel()
    {
        //float.TryParse(trigger.labelStrength, out float labelStrength);

        if (trigger.boxStrength != trigger.labelStrength)
        {
            errorMsgs.text = "The strength on the label does not match the box";
            errorMsgs.enabled = true;
            return false;
        }
        else if (trigger.boxMedicationName == trigger.labelMedicationName) 
        {
            //errorMsgs.text = " Names Match";
            CheckPrescription();
            return true;
        }
        else
        {
            errorMsgs.text = "The name and or the strengths on the label and box do not match";
            errorMsgs.enabled = true;
            return false;
        }

    }

    private void CheckPrescription()
    {
        nameError = CheckMedicationBoxName();
        //strengthError = CheckMedicationBoxStrength();

        if (nameError) 
        {
            errorMsgs.text = "well done";
            errorMsgs.enabled = true;
        } else
        {
            errorMsgs.text = String.Join("\n",errors);
            errorMsgs.enabled = true;
        }
    }

    private bool CheckMedicationBoxStrength()
    {
        if (trigger.boxStrength == medication.Strength)
        {
            return true;
        } else
        {
            string error = "The medication strength on the prescription does not match what you are trying to dispense.";
            errors.Add(error);
            return false;
        }
    }

    private bool CheckMedicationBoxName()
    {
        if (trigger.boxMedicationName == medication.MedicationName)
        {
            return true;
        }
        else
        {
            string error = "The medication name on the prescription does not match what you are trying to dispense.";
            errors.Add(error);
            return false;
        }
    }

    private Doctor getRandomDoctor(List<Doctor> dData)
    {

        if (dData.Count <= 0)
        { 
            throw new ArgumentException("No doctors added");
        } 
        else
        {
            System.Random rand = new System.Random();

            int dIndex = rand.Next(dData.Count);
        
            Debug.Log("Random index " + dIndex);

            Doctor d = dData[dIndex];
            
            
        return d;
        }
    }

    private Patient getRandomPatient(List<Patient> pData)
    {
        if (pData.Count <= 0)
        {
            throw new ArgumentException("No patients added");
        }
        else
        {
            System.Random rand = new System.Random();

            int pIndex = rand.Next(pData.Count);

            Patient p = pData[pIndex];

            return p;
        }
    }

    private Medication getRandomMedication(List<Medication> mData)
    {

        if (mData.Count <= 0)
        {
            throw new ArgumentException("No medication added");
        }
        else
        {
            System.Random rand = new System.Random();

            int mIndex = rand.Next(mData.Count);
            //Debug.Log($"Medication {mIndex}");
            Medication m = mData[mIndex];


        return m;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
