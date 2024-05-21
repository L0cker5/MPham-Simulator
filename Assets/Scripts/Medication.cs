using System;
using UnityEngine;

/// <summary>
/// Represents a _medication with properties including name, strength, type, dose, frequency, and more.
/// It includes validation for these properties to ensure they fall within acceptable ranges and constraints.
/// </summary>
public class Medication
{

    private string _medicationName;
    private float _strength;
    private StrengthUnit _strengthUnit;
    private MedicationType _medicationType;
    private string _dose;
    private int _expectedDose;
    private string _dosingFrequency;
    private int _quantity;
    private string _bnfLabels;
    private bool _isOutOfDate;
    private bool _isSigned;


    /// <summary>
    /// Initializes a new instance of the Medication class.
    /// </summary>
    public Medication() { }

    /// <summary>
    /// Initializes a new instance of the Medication class with specified parameters.
    /// </summary>
    /// <param name="medication">The name of the _medication.</param>
    /// <param name="strength">The strength of the _medication.</param>
    /// <param name="strengthUnit">The unit of the strength.</param>
    /// <param name="medicationType">The type of the _medication.</param>
    /// <param name="dose">The dose of the _medication.</param>
    /// <param name="expectedDose">The expected dose of the _medication.</param>
    /// <param name="dosingFrequency">The dosing frequency.</param>
    /// <param name="quantity">The quantity of the _medication.</param>
    /// <param name="bnfLabels">The BNF labels for the _medication.</param>
    /// <param name="isOutOfDate">Indicates if the _medication is out of date.</param>
    /// <param name="isSigned">Indicates if the _medication is signed.</param>
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


    //Must be non-null, between 1 and 50 characters.
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

    //Must be between 1 and 10000.
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

    //gets or sets the current StrengthUnit emun.
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

    //gets or sets the current MedicationType emun.
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

    //Must be non-null, between 1 and 50 characters.
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

    //Must be between 1 and 100.
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

    //Must be non-null, between 1 and 50 characters.
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

    //Must be between 1 and 100.
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

    //Must be between 1 and 50 characters and can be null.
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

    //holds true or faulse to determine if the displayed prescription should have an incorrect date
    public bool IsOutOfDate
    {
        get { return _isOutOfDate; }

        set { _isOutOfDate = value; }
    }

    //holds true fo false to determine is the displayed prescription should be signed b the doctor or not
    public bool IsSigned
    {
        get { return _isSigned; }

        set { _isSigned = value; }
    }

    // Returns a formatted string representation of the _medication details
    public string PrintMedicationToScript()
    {
        string print = (MedicationName + " " + Strength + " " + StrengthUnit + " " + MedicationType + "\n"
            + Dose + " " + DosingFrequency + "\n"
            + "x " + Quantity);
        return print;
    }
}
