using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadCSV : MonoBehaviour
{
    
    void Awake()
    {
        //List<Medication> readMedication = readMedicationData();

        //Debug.Log("Medication file " + readMeds.Count);
        //foreach (Medication medications in readMeds)
        //{
        //    Debug.Log("Medication file name: " + medications.medicationName);
        //}


        //List<Patient> readPatient = readPatientData();

        //Debug.Log("Patient file " + readPatient.Count);
        //foreach (Patient patients in readPatient)
        //{
        //    Debug.Log("Patient file date: " + patients.dateOfBirth);
        //}

        //List<Doctor> readDoctor = readDoctorData();

        //Debug.Log("Doctor file " + readDoctor.Count);
        //foreach (Doctor doctors in readDoctor)
        //{
        //    Debug.Log("Doctor file date: " + doctors.name);
        //}
    }

    public static List<Medication> readMedicationData()
    {
        List<Medication> medicationsFromFile = new List<Medication>();
        string file = "medicationdata";
        int date, signed;

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
                        
                                Medication m = new Medication();
                                //if there is no data in the row it will leave it blank
                                m.MedicationName = row[0];
                                float st = float.Parse(row[1]);
                                m.Strength = st;
                                //int.TryParse(row[1], out m.strength);
                                m.StrengthUnit = row[2].ToUpper();
                                m.MedicationType = row[3].ToUpper();
                                m.Dose = row[4];
                                int ed = int.Parse(row[5]);
                                m.ExpectedDose = ed;
                                //int.TryParse(row[5], out m.expectedDose);
                                m.DosingFrequency = row[6];
                                int qt = int.Parse(row[7]);
                                m.Quantity = qt;
                                //int.TryParse(row[7], out m.quantity);
                                m.BnfLabels = row[8];
                                date = int.Parse(row[9]);
                                
                                //int.TryParse(row[9], out date);

                                if (date == 0)
                                {
                                    m.IsOutOfDate = false;
                                }
                                else if (date == 1)
                                {
                                    m.IsOutOfDate = true;
                                }
                                else
                                {
                                    throw new ArgumentException("Cannot be a value other than 0 or 1");
                                }

                                int.TryParse(row[10], out signed);

                                if (signed == 0)
                                {
                                    m.IsSigned = false;
                                }
                                else if (signed == 1)
                                {
                                    m.IsSigned = true;
                                }
                                else
                                {
                                    throw new ArgumentException("Cannot be a value other than 0 or 1");
                                }

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

        Debug.Log("File meds length after for in ReadCSV " + medicationsFromFile.Count);

        return medicationsFromFile;
    }

    public static List<Patient> readPatientData()
    {
        List<Patient> patientsFromFile = new List<Patient>();
        string file = "dummypatientdata";
        //int date, signed;

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

                            Patient p = new Patient();
                            //if there is no data in the row it will leave it blank
                            
                            p.name = row[0];
                            p.address = row[1];
                            p.city = row[2];
                            //var dateInfo = new DateInfo("dd-mm-yyy");
                            DateTime.TryParse(row[3], out p.dateOfBirth);

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
