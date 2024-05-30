using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// Used to read in data from bnflabels.csv, dummydoctordata.csv, dummypatientdata.csv & medicationdata.csv
/// </summary>
public class ReadCSV : MonoBehaviour
{

    /// <summary>
    /// Reads in data from medicationdata.csv and stores it as a list of Medication objects 
    /// </summary>
    /// <returns>List of Medications</returns>
    /// <exception cref="FileNotFoundException"></exception>
    public static List<Medication> ReadMedicationData()
    {
        List<Medication> medicationsFromFile = new List<Medication>();
        string file = "medicationdata";

        TextAsset medicationData = Resources.Load<TextAsset>(file);

        if (medicationData == null)
        {
            Debug.Log("File not read");
            throw new FileNotFoundException(file + " not read");
        }
        else
        {
            Debug.Log("File read");
            try
            {

                string[] data = medicationData.text.Split(new char[] { '\n' });

                Debug.Log("File meds length before for in ReadCSV " + medicationsFromFile.Count);

                if (data.Length > 0)
                {
                    //read the data skipping the first header line
                    for (int i = 1; i < data.Length - 1; i++)
                    {
                        string[] row = data[i].Split(new char[] { ',' });

                        // if the first field is empty skip the line
                        if (row[0] != "")
                        {
                            float st = float.Parse(row[1]);

                            StrengthUnit sU;
                            Enum.TryParse(row[2], out sU);

                            MedicationType mT;
                            Enum.TryParse(row[3], out mT);

                            int ed = int.Parse(row[5]);
                            int qt = int.Parse(row[7]);
                            int date = int.Parse(row[9]);

                            bool dateBool;

                            if (date == 0)
                            {
                                dateBool = false;
                            }
                            else if (date == 1)
                            {
                                dateBool = true;
                            }
                            else
                            {
                                throw new ArgumentException("Cannot be a value other than 0 or 1");
                            }

                            int signed = int.Parse(row[10]);
                            bool signedBool;

                            if (signed == 0)
                            {
                                signedBool = false;
                            }
                            else if (signed == 1)
                            {
                                signedBool = true;
                            }
                            else
                            {
                                throw new ArgumentException("Cannot be a value other than 0 or 1");
                            }

                            Medication m = new Medication(row[0].Trim(), st, sU, mT, row[4].Trim(),
                                ed, row[6].Trim(), qt, row[8].Trim(), dateBool, signedBool);

                            medicationsFromFile.Add(m);
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("File is empty");
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Exception" + e);
                Console.WriteLine("Exception" + e);
            }
        }

        Debug.Log("Random File meds length after for in ReadCSV " + medicationsFromFile.Count);

        return medicationsFromFile;
    }

    /// <summary>
    /// Reads in data from dummypatientdata.csv and stores it as a list of Patient objects 
    /// </summary>
    /// <returns>A list of Patients</returns>
    /// <exception cref="FileNotFoundException"></exception>
    public static List<Patient> ReadPatientData()
    {
        List<Patient> patientsFromFile = new List<Patient>();
        string file = "dummypatientdata";

        TextAsset patientData = Resources.Load<TextAsset>(file);

        if (patientData == null)
        {
            Debug.Log("File not read");
            throw new FileNotFoundException(file + " not read");
        }
        else
        {
            Debug.Log("File read");
            try
            {

                string[] data = patientData.text.Split(new char[] { '\n' });

                Debug.Log("File patient length before for in ReadCSV " + patientsFromFile.Count);

                if (data.Length > 0)
                {
                    //read the data skipping the first header line
                    for (int i = 1; i < data.Length - 1; i++)
                    {
                        string[] row = data[i].Split(new char[] { ',' });

                        // if the first field is empty skip the line
                        if (row[0] != "")
                        {
                            //if there is no data in the row it will leave it blank
                            DateTime dateTime;

                            //string wrongDob = "30/02/2020";
                            string dob = row[3];
                            bool isValid = IsValidDate(dob);
                            if (isValid == false)
                            {
                                throw new ArgumentException("Date is not valid");
                            }
                            else
                            {
                                DateTime.TryParse(dob, out dateTime);
                            }

                            Patient p = new Patient(row[0].Trim(), row[1].Trim(), row[2].Trim(), dateTime);

                            patientsFromFile.Add(p);
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("File is empty");
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Exception" + e);
                Console.WriteLine("Exception" + e);
            }
        }
        Debug.Log("File patient length after for in ReadCSV " + patientsFromFile.Count);

        return patientsFromFile;
    }

    /// <summary>
    /// Checks if the date entered is a valid date
    /// </summary>
    /// <param name="dateTime">the date to be checked</param>
    /// <returns>true of false</returns>
    private static bool IsValidDate(string dateTime)
    {
        DateTime temp;
        return DateTime.TryParse(dateTime, out temp);

    }

    /// <summary>
    /// Reads in data from dummydoctordata.csv and stores it as a list of Doctor objects 
    /// </summary>
    /// <returns>A List of Doctors</returns>
    /// <exception cref="FileNotFoundException"></exception>
    public static List<Doctor> ReadDoctorData()
    {
        List<Doctor> doctorsFromFile = new List<Doctor>();
        string file = "dummydoctordata";

        TextAsset doctorData = Resources.Load<TextAsset>(file);

        if (doctorData == null)
        {
            Debug.Log("File not read");
            throw new FileNotFoundException(file + " not read");
        }
        else
        {
            Debug.Log("File read");
            try
            {
                string[] data = doctorData.text.Split(new char[] { '\n' });

                Debug.Log("File doctor length before for in ReadCSV " + doctorsFromFile.Count);

                if (data.Length > 0)
                {
                    //read the data skipping the first header line
                    for (int i = 1; i < data.Length - 1; i++)
                    {
                        string[] row = data[i].Split(new char[] { ',' });

                        // if the first field is empty skip the line
                        if (row[0] != "")
                        {
                            Doctor d = new Doctor(row[0].Trim(), row[1].Trim(), row[2].Trim(), row[3].Trim(), row[4].Trim(), row[5].Trim());

                            doctorsFromFile.Add(d);
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("File is empty");
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Exception" + e);
                Console.WriteLine("Exception" + e);
            }
        }
        Debug.Log("File doctor length after for in ReadCSV " + doctorsFromFile.Count);
        return doctorsFromFile;
    }

    /// <summary>
    /// Reads in data from bnflabels.csv and stores it as a list of BNF Label objects 
    /// </summary>
    /// <returns>List of BNF Labels</returns>
    /// <exception cref="FileNotFoundException"></exception>
    public static List<BnfLabel> ReadBnfData()
    {
        List<BnfLabel> bnfFromFile = new List<BnfLabel>();
        string file = "bnflabels";

        TextAsset bnfData = Resources.Load<TextAsset>(file);

        if (bnfData == null)
        {
            Debug.Log("BNF file not read");
            throw new FileNotFoundException(file + " not read");
        }
        else
        {
            Debug.Log("File read");
            try
            {
                string[] data = bnfData.text.Split(new char[] { '\n' });


                if (data.Length > 0)
                {
                    //read the data skipping the first header line
                    for (int i = 1; i < data.Length - 1; i++)
                    {
                        string[] row = data[i].Split(new char[] { ',' });

                        // if the first field is empty skip the line
                        if (row[0] != "")
                        {
                            int num = int.Parse(row[0]);

                            BnfLabel b = new BnfLabel(num, row[1].Trim());

                            bnfFromFile.Add(b);
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("File is empty");
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Exception" + e);
                Console.WriteLine("Exception" + e);
            }
        }
        Debug.Log("File bnf length after for in ReadCSV " + bnfFromFile.Count);
        return bnfFromFile;
    }

}
