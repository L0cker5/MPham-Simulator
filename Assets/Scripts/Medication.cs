using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medication
{

    public string medicationName;
    public float strength;
    public string strengthUnit;
    //public Medicationtype medicationType;
    public string medicationType;
    public string dose;
    public int expectedDose;
    public string dosingFrequency;
    public int quantity;
    public string bnfLabels;
    public bool isOutOfDate;
    public bool isSigned;


    //public void printDetails()
    //{
    //    Debug.Log("Medication Name: " + medicationName);
    //    Debug.Log("Medication : " + strength + strengthUnit + " " + medicationType);
    //    Debug.Log("Medication Dose : " + dose + " " + dosingFrequency);
    //}

    public string MedicationName
    {
        get { return medicationName; }
     
        set { medicationName = value; }
    }

    public float Strength
    {
        get { return strength; }

        set { strength = value; }
    }

    public string StrengthUnit
    {
        get { return strengthUnit; }

        set { strengthUnit = value; }
    }
    public string MedicationType
    {
        get { return medicationType; }

        set { medicationType = value; }
    }

    public string Dose
    {
        get { return dose; }

        set { dose = value; }
    }

    public int ExpectedDose
    {
        get { return expectedDose; }

        set { expectedDose = value; }
    }

    public string DosingFrequency
    {
        get { return dosingFrequency; }

        set { dosingFrequency = value; }
    }

    public int Quantity
    {
        get { return quantity; }

        set { quantity = value; }
    }

    public string BnfLabels
    {
        get { return bnfLabels; }

        set { bnfLabels = value; }
    }

    public bool IsOutOfDate
    {
        get { return isOutOfDate; }

        set { isOutOfDate = value; }
    }

    public bool IsSigned
    {
        get { return isSigned; }

        set { isSigned = value; }
    }
}
