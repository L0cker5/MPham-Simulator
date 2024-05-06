using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSimulator : MonoBehaviour
{

    private List<Medication> medicationData;
    private List<Patient> patientData;
    private List<Doctor> doctorData;

    //private System.Random rand = new System.Random();

    //PrescriptionProperties pProps = new PrescriptionProperties();

    public Medication medication;
    public Patient patient;
    public Doctor doctor;

    private void Awake()
    {
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
