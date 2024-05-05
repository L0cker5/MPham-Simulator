using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadCSV : MonoBehaviour
{
    
    public static List<Medication> readMedicationData()
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

                            //Do i need a try catch around this???????????************************
                        
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

                            Medication m = new Medication(row[0], st, sU, mT, row[4],
                                ed, row[6], qt, row[8], dateBool, signedBool );

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

    public static List<Patient> readPatientData()
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

                            //Do i need a try catch around this???????????************************

                            //if there is no data in the row it will leave it blank
                            DateTime dateTime;

                            //string dob = "30/02/2020";
                            string dob = row[3];
                            bool isValid = IsValidDate(dob);
                            if ( isValid == false)
                            {
                                throw new ArgumentException("Date is not valid");
                            }
                            else
                            {
                                DateTime.TryParse (dob, out dateTime);
                            }

                            Patient p = new Patient(row[0], row[1], row[2], dateTime);

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

    private static bool IsValidDate(string dateTime)
    {
        DateTime temp;
        return DateTime.TryParse(dateTime, out temp);

    }

    public static List<Doctor> readDoctorData()
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

                            //Do i need a try catch around this???????????************************

                            Doctor d = new Doctor();
                            //if there is no data in the row it will leave it blank

                            d.name = row[0];
                            d.signature = row[1];
                            d.healthCentre = row[2];
                            d.addressLineOne = row[3];
                            d.town = row[4];
                            d.postcode = row[5];

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
    // Update is called once per frame
    void Update()
    {
        
    }
}
