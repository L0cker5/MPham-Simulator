using System;
using System.Net;
using System.Text.RegularExpressions;

/// <summary>
/// Represents a doctors details for use on the prescription
/// </summary>
public class Doctor
{
    private string _name;
    private string _signature;
    private string _healthCentre;
    private string _addressLineOne;
    private string _city;
    private string _postcode;


    /// <summary>
    /// Initializes a new instance of the Doctor class.
    /// </summary>
    public Doctor() { }

    /// <summary>
    /// Initializes a new instance of the Doctor class with specified parameters.
    /// </summary>
    /// <param name="name">The Doctors name</param>
    /// <param name="signature">The Doctors signature</param>
    /// <param name="healthCentre">The name of the health center the doctor works</param>
    /// <param name="addressLineOne">The address line of the health center the doctor works</param>
    /// <param name="city">The city of the health center the doctor works</param>
    /// <param name="postcode">The postcode of the health center the doctor works</param>
    public Doctor(String name, String signature, String healthCentre, String addressLineOne,  String city, String postcode) 
    {
        this.Name = name;
        this.Signature = signature;
        this.HealthCentre = healthCentre;
        this.AddressLineOne = addressLineOne;
        this.City = city;
        this.Postcode = postcode;
    }

    // Must not be null, must be between 1 and 50 characters.
    public string Name
    {
        get { return _name; }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Doctor name cannot be null");
            }
            else if (value.Length <= 0 || value.Length > 50)
            {
                throw new ArgumentException("Invalid length of doctor name");
            }
            else { this._name = value; }
        }
    }

    // Must not be null, must be between 1 and 50 characters.
    public string Signature
    { 
        get { return _signature; }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Doctor signature cannot be null");
            }
            else if (value.Length <= 0 || value.Length > 50)
            {
                throw new ArgumentException("Invalid length of doctor signature");
            }
            else { this._signature = value; }
        }
    }

    // Must not be null, must be between 1 and 50 characters.
    public string HealthCentre
    {
        get { return _healthCentre; }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Health Centre cannot be null");
            }
            else if (value.Length <= 0 || value.Length > 50)
            {
                throw new ArgumentException("Invalid length of Health Centre");
            }
            else { this._healthCentre = value; }
        }
    }

    // Must not be null, must be between 1 and 50 characters.
    public string AddressLineOne
    {
        get { return _addressLineOne; }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Address Line One cannot be null");
            }
            else if (value.Length <= 0 || value.Length > 50)
            {
                throw new ArgumentException("Invalid length of Address Line One");
            }
            else { this._addressLineOne = value; }
        }
    }

    // Must not be null, must be between 1 and 50 characters.
    public string City
    {
        get { return _city; }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Town cannot be null");
            }
            else if (value.Length <= 0 || value.Length > 50)
            {
                throw new ArgumentException("Invalid length of city");
            }
            else { this._city = value; }
        }
    }

    // Must not be null, and match the set regex pattern.
    public string Postcode
    {
        get { return _postcode; }
        set
        {
            Regex regex = new Regex("^BT[0-9]{1,2}[\\s]*([\\d][A-Za-z]{2})$");

            if (value == null)
            {
                throw new ArgumentNullException("Postcode cannot be null");
            }
            else if (!regex.IsMatch(value))
            {
                throw new ArgumentException("Invalid postcode");
            }
            else
            {
                _postcode = value;
            }
        }
    }

    // Returns a formatted string representation of the doctors name and address details.
    public string PrintDoctorToScript()
    {
        string print = Name + "\n" + HealthCentre + "\n" + AddressLineOne + "\n" + City + "\n" + Postcode;

        return print;
    }

}
