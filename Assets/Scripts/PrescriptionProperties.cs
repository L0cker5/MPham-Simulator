using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PrescriptionProperties : MonoBehaviour
{
    [SerializeField]
    private TMP_Text tmpPatientAge, tmpPatientDob, tmpPatientDetails, tmpMedicationInfo, tmpDoctorDetails, tmpDoctorSignature, tmpDoctorDate;

    //private String patientAge, patientDob, patientDetails, medicationInfo, doctorDetails, doctorSignature, doctorDate;

    private List<Medication> medicationData;
    private List<Patient> patientData;
    private List<Doctor> doctorData;

    public Medication prescription = new Medication();
    public Patient patient = new Patient();
    public Doctor doctor = new Doctor();


    // Start is called before the first frame update
    void Awake()
    {
        //get the lists of prescription, patient & doctor data
        medicationData = ReadCSV.readMedicationData();
        patientData = ReadCSV.readPatientData();
        doctorData = ReadCSV.readDoctorData();

        //call the methods to get a random prescription, patient & doctor for the lists
        prescription = getRandomMedication(medicationData);
        patient = getRandomPatient(patientData);
        doctor = getRandomDoctor(doctorData);

        AddInfoToScript();
    }

    public void AddInfoToScript()
    {
        
        //SimulatorManager start = gameObject.AddComponent<SimulatorManager>();

        bool signed, checkIsSigned, isOutOfDate;

        tmpMedicationInfo.text = prescription.PrintMedicationToScript();

        checkIsSigned = prescription.IsSigned;
        signed = CheckIfScriptIsSigned(checkIsSigned);
        
        if (signed == true)
        {
            tmpDoctorSignature.text = doctor.Signature;
        } else
        {
            tmpDoctorSignature.text = "";
        }
                
        isOutOfDate = prescription.IsOutOfDate;
        tmpDoctorDate.text = CheckIfScriptHasValidDate(isOutOfDate);
        
        tmpPatientDetails.text = patient.PrintPatientToScript();
        
        DateTime patientDob = patient.DateOfBirth;
        Debug.Log("Patient dob: " + patientDob);
        tmpPatientDob.text = patientDob.ToString("dd-MM-yyyy");

        Debug.Log("Patient dob: " + patientDob);
        DateTime todaysDate = DateTime.Today;
        int age = todaysDate.Year - patientDob.Year;
        tmpPatientAge.text = age.ToString();
 
        tmpDoctorDetails.text = doctor.PrintDoctorToScript();


    }

    private string CheckIfScriptHasValidDate(bool isOutOfDate)
    {
        DateTime date;
        string newDate;
        if (isOutOfDate == true)
        {
            date = DateTime.Now.AddDays(-31);

            newDate = date.ToString("dd-MM-yyyy");

            return newDate;
        }
        else
        {
            date = DateTime.Now;
            newDate = date.ToString("dd-MM-yy");
            
            return newDate;
        }
    }

    private bool CheckIfScriptIsSigned(bool isSigned)
    {
        if (isSigned == true)
        {
            return true;
        }
        else
        {
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
            throw new ArgumentException("No prescription added");
        }
        else
        {
            System.Random rand = new System.Random();

            int mIndex = rand.Next(mData.Count);
            //Debug.Log($"Medication {mIndex}");
            Medication m = mData[mIndex];
            //m.PrintMedicationToScript();

            return m;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
