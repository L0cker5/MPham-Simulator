using System;
using UnityEngine;

public class Medication
{

    private string _medicationName;
    private float _strength;
    //private string _strengthUnit;
    private StrengthUnit _strengthUnit;
    //private string _medicationType;
    private MedicationType _medicationType;
    private string _dose;
    private int _expectedDose;
    private string _dosingFrequency;
    private int _quantity;
    private string _bnfLabels;
    private bool _isOutOfDate;
    private bool _isSigned;

    public Medication() { }

    public Medication(String medication, float strength, StrengthUnit strengthUnit, MedicationType medicationType, String dose,
    int expectedDose, String dosingFrequency, int quantity, string bnfLabels, bool isOutOfDate, bool isSigned)
    {
    
        this.MedicationName = medication;
        this.Strength = strength;
        this.StrengthUnit = strengthUnit;
        this.MedicationType = medicationType;
        this.Dose = dose;
        this.ExpectedDose = expectedDose;
        this.DosingFrequency = dosingFrequency;
        this.Quantity = quantity;
        this.BnfLabels = bnfLabels;
        this.IsOutOfDate = isOutOfDate;
        this.IsSigned = isSigned;
    }

    public string MedicationName
    {
        get { return _medicationName; }
     
        set 
        {
            if (value == null)
            {
                throw new ArgumentNullException("Medication name cannot be null");
            } 
            else if (value.Length <= 0 || value.Length > 50)
            {
                throw new ArgumentOutOfRangeException("Invalid length of prescription name");
            }
            else { this._medicationName = value; }
             
        }
    }

    public float Strength
    {
        get { return _strength; }

        set 
        { 
            if (value <=0 || value > 10000) 
            {
                throw new ArgumentException("Strength out of range");
            }
            else { this._strength = value; }
        }
    }

    public StrengthUnit StrengthUnit
    {
        get { return _strengthUnit; }

        set 
        { 
            if (Enum.IsDefined(typeof(StrengthUnit),value))
            {
                this._strengthUnit = value;
            }
            else
            {
                throw new ArgumentException("Invalid strength unit enum value.");
            }
        }
    }
    public MedicationType MedicationType
    {
        get { return _medicationType; }

        set
        {
            if (Enum.IsDefined(typeof(MedicationType), value))
            {
                this._medicationType = value;
            }
            else
            {
                throw new ArgumentException("Invalid prescription type enum value.");
            }
        }
    }

    public string Dose
    {
        get { return _dose; }

        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Dose cannot be null");
            }
            else if (value.Length <= 0 || value.Length > 50)
            {
                throw new ArgumentOutOfRangeException("Invalid length of dose");
            }
            else { this._dose = value; }
        }
    }

    public int ExpectedDose
    {
        get { return _expectedDose; }

        set
        {
            if (value <= 0 || value > 100)
            {
                throw new ArgumentException("Expected dose out of range");
            }
            else { this._expectedDose = value; }
        }
    }

    public string DosingFrequency
    {
        get { return _dosingFrequency; }

        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Dosing frequency cannot be null");
            }
            else if (value.Length <= 0 || value.Length > 50)
            {
                throw new ArgumentOutOfRangeException("Invalid length of dose");
            }
            else { this._dosingFrequency = value; }
        }
    }

    public int Quantity
    {
        get { return _quantity; }

        set
        {
            if (value <= 0 || value > 100)
            {
                throw new ArgumentException("Expected dose out of range");
            }
            else { this._quantity = value; }
        }
    }

    public string BnfLabels
    {
        get { return _bnfLabels; }

        set
        {
            if (value.Length < 0 || value.Length > 50)
            {
                throw new ArgumentOutOfRangeException("Invalid length of BNF Label");
            }
            else { this._bnfLabels = value; }
        }
    }

    public bool IsOutOfDate
    {
        get { return _isOutOfDate; }

        set { _isOutOfDate = value; }
    }

    public bool IsSigned
    {
        get { return _isSigned; }

        set { _isSigned = value; }
    }

    public void PrintDetails()
    {
        Debug.Log("Medication Name: " + _medicationName);
        Debug.Log("Medication : " + _strength + _strengthUnit + " " + _medicationType);
        Debug.Log("Medication Dose : " + _dose + " " + _dosingFrequency);
    }

    public string PrintMedicationToScript()
    {
        string print = (MedicationName + " " + Strength + " " + StrengthUnit + " " + MedicationType + "\n"
            + Dose + " " + DosingFrequency + "\n"
            + "x " + Quantity);
        return print;
    }
}
