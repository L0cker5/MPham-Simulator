using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSimulator : MonoBehaviour
{

    private List<Medication> medicationData;
    private List<Patient> patientData;
    private List<Doctor> doctorData;

    private System.Random rand = new System.Random();

    private void Awake()
    {
        //get the lists of medication, patient & doctor data
        medicationData = ReadCSV.readMedicationData();
        patientData = ReadCSV.readPatientData();
        doctorData = ReadCSV.readDoctorData();

        //call the methods to get a random medication, patient & doctor for the lists
        Medication medication = getRandomMedication();
        Patient patient = getRandomPatient();
        Doctor doctor = getRandomDoctor();

        string med = medication.PrintToScript();
        Debug.Log("Random:\n" + med);
        Debug.Log("Random Medication: " + medication.MedicationName + " " + medication.Strength + " " + medication.StrengthUnit + " " + medication.MedicationType + " BNF: " + medication.BnfLabels);
        Debug.Log("Random Patient: " + patient.Name + " DOB: " + patient.DateOfBirth);
        Debug.Log("Random Doctor:  " + doctor.name);


    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private Doctor getRandomDoctor()
    {
        //System.Random rand = new System.Random();
        
        int dIndex = rand.Next(doctorData.Count);

        Doctor d = doctorData[dIndex];

        return d;
    }

    private Patient getRandomPatient()
    {
        //System.Random rand = new System.Random();

        int pIndex = rand.Next(patientData.Count);

        Patient p = patientData[pIndex];

        return p;
    }

    private Medication getRandomMedication()
    {
        int mIndex = rand.Next(medicationData.Count);
        //Debug.Log($"Medication {mIndex}");
        Medication m = medicationData[mIndex];

        return m;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
