using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Attached to the prescription to display information about the patient, doctor and medication to be prescribed
/// </summary>
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


    /// <summary>
    /// Accesses the readCSV class and reads in the data from the medicationdata.csv, dummydoctordata.csv & dummypatientdata.csv
    /// then gets a random element from each of the list. The info is then displayed on the prescription GameObject
    /// </summary>
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

    /// <summary>
    /// Displays then information on the prescription GameObject
    /// </summary>
    public void AddInfoToScript()
    {

        bool signed, checkIsSigned, isOutOfDate;

        // Sets the text of the medication to be dispenced to the text field
        tmpMedicationInfo.text = prescription.PrintMedicationToScript();

        // Checks if the prescription has been signed
        checkIsSigned = prescription.IsSigned;
        signed = CheckIfScriptIsSigned(checkIsSigned);
        
        if (signed == true)
        {
            tmpDoctorSignature.text = doctor.Signature;
        } else
        {
            tmpDoctorSignature.text = "";
        }
        
        // Checks if the prescription is out of date
        isOutOfDate = prescription.IsOutOfDate;
        tmpDoctorDate.text = CheckIfScriptHasValidDate(isOutOfDate);

        // Sets the text of the patient to be displayed to the text field
        tmpPatientDetails.text = patient.PrintPatientToScript();
        
        // Sets the patients date of birth to be dispalyed
        DateTime patientDob = patient.DateOfBirth;
        //Debug.Log("Patient dob: " + patientDob);
        tmpPatientDob.text = patientDob.ToString("dd-MM-yyyy");

        // Calculates the patients age based on the current date 
        //Debug.Log("Patient dob: " + patientDob);
        DateTime todaysDate = DateTime.Today;
        int age = todaysDate.Year - patientDob.Year;
        // Sets the patients age to be dispalyed
        tmpPatientAge.text = age.ToString();
        // Sets the doctors information to be dispalyed
        tmpDoctorDetails.text = doctor.PrintDoctorToScript();


    }

    /// <summary>
    /// Checks the boolean value to determine if the prescripton should display a valid or invalid date.
    /// If true the date is invalid and the current date is set for minus 31 days which makes a prescription
    /// out of date and shoudl not be dispensed to the patient
    /// </summary>
    /// <param name="isOutOfDate">true or false</param>
    /// <returns>Date as a string</returns>
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

    /// <summary>
    /// Checks the boolean value to determine if the prescripton have been signed by the doctor.
    /// If true the script has been signed and is ok to dispense. If false the signature is 
    /// left blank and the medication should not be dispensed.
    /// </summary>
    /// <param name="isSigned">true or false</param>
    /// <returns>true or false</returns>
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

    /// <summary>
    /// Gets a random Doctor from the list of Dcotors. 
    /// </summary>
    /// <param name="dData">List of Doctors from the dummydoctordata.csv</param>
    /// <returns>A Doctor for the list</returns>
    /// <exception cref="ArgumentException">throws and exception if the list of Doctors is empty</exception>
    private Doctor getRandomDoctor(List<Doctor> dData)
    {

        if (dData.Count <= 0)
        {
            throw new ArgumentException("No doctors added");
        }
        else
        {
            System.Random rand = new System.Random();

            // Random int chosen based on the number of elements in the list
            int dIndex = rand.Next(dData.Count);

            Debug.Log("Random index " + dIndex);

            Doctor d = dData[dIndex];


            return d;
        }
    }

    /// <summary>
    /// Gets a random Patient from the list of Patients. 
    /// </summary>
    /// <param name="pData">List of Patients from the dummypatientdata.csv</param>
    /// <returns>A Patient from the list</returns>
    /// <exception cref="ArgumentException">throws and exception if the list of Patients is empty</exception>
    private Patient getRandomPatient(List<Patient> pData)
    {
        if (pData.Count <= 0)
        {
            throw new ArgumentException("No patients added");
        }
        else
        {
            System.Random rand = new System.Random();

            // Random int chosen based on the number of elements in the list
            int pIndex = rand.Next(pData.Count);

            Patient p = pData[pIndex];

            return p;
        }
    }

    /// <summary>
    /// Gets a random Medication from the list of Medications.
    /// </summary>
    /// <param name="mData">List of Medications from the medicationdata.csv</param>
    /// <returns>A Medication from the list</returns>
    /// <exception cref="ArgumentException">throws and exception if the list of Medications is empty</exception>
    private Medication getRandomMedication(List<Medication> mData)
    {

        if (mData.Count <= 0)
        {
            throw new ArgumentException("No prescription added");
        }
        else
        {
            System.Random rand = new System.Random();

            // Random int chosen based on the number of elements in the list
            int mIndex = rand.Next(mData.Count);
            //Debug.Log($"Medication {mIndex}");
            Medication m = mData[mIndex];
            //m.PrintMedicationToScript();

            return m;
        }
    }

}
