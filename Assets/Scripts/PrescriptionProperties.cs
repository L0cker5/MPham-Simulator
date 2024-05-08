using System;
using TMPro;
using UnityEngine;

public class PrescriptionProperties : MonoBehaviour
{
    [SerializeField]
    private TMP_Text tmpPatientAge, tmpPatientDob, tmpPatientDetails, tmpMedicationInfo, tmpDoctorDetails, tmpDoctorSignature, tmpDoctorDate;
    
    //private String patientAge, patientDob, patientDetails, medicationInfo, doctorDetails, doctorSignature, doctorDate;

    
    //private Medication _medication = new Medication();
    //private Patient _patient = new Patient();
    //private Doctor _doctor = new Doctor();


    // Start is called before the first frame update
    void Awake()
    {
        AddInfoToScript();
    }

    private void AddInfoToScript()
    {
        StartSimulator start = gameObject.AddComponent<StartSimulator>();
        
        bool signed, checkIsSigned, isOutOfDate;

        tmpMedicationInfo.text = start.medication.PrintMedicationToScript();

        checkIsSigned = start.medication.IsSigned;
        signed = CheckIfScriptIsSigned(checkIsSigned);
        
        if ( signed )
        {
            tmpDoctorSignature.text = start.doctor.Signature;
        } else
        {
            tmpDoctorSignature.text = "";
        }
                
        isOutOfDate = start.medication.IsOutOfDate;
        tmpDoctorDate.text = CheckIfScriptHasValidDate(isOutOfDate);
        
        tmpPatientDetails.text = start.patient.PrintPatientToScript();
        
        DateTime patientDob = start.patient.DateOfBirth;
        tmpPatientDob.text = patientDob.ToString("dd-MM-yyyy");
        
        DateTime todaysDate = DateTime.Today;
        int age = todaysDate.Year - patientDob.Year;
        tmpPatientAge.text = age.ToString();
 
        tmpDoctorDetails.text = start.doctor.PrintDoctorToScript();


    }

    private string CheckIfScriptHasValidDate(bool isOutOfDate)
    {
        DateTime date;
        string newDate;
        if (isOutOfDate)
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
        if (isSigned)
        {
            return true;
        }
        else
        {
            return false;
        }

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
