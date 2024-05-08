using System;
using System.Net;
using System.Text.RegularExpressions;

public class Doctor
{
    
    private string _name;
    private string _signature;
    private string _healthCentre;
    private string _addressLineOne;
    private string _city;
    private string _postcode;

    public Doctor() { }

    public Doctor(String name, String signature, String healthCentre, String addressLineOne,  String city, String postcode) 
    {
        this.Name = name;
        this.Signature = signature;
        this.HealthCentre = healthCentre;
        this.AddressLineOne = addressLineOne;
        this.City = city;
        this.Postcode = postcode;
    }

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
                throw new ArgumentOutOfRangeException("Invalid length of doctor name");
            }
            else { this._name = value; }
        }
    }
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
                throw new ArgumentOutOfRangeException("Invalid length of doctor signature");
            }
            else { this._signature = value; }
        }
    }
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
                throw new ArgumentOutOfRangeException("Invalid length of Health Centre");
            }
            else { this._healthCentre = value; }
        }
    }
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
                throw new ArgumentOutOfRangeException("Invalid length of Address Line One");
            }
            else { this._addressLineOne = value; }
        }
    }
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
                throw new ArgumentOutOfRangeException("Invalid length of city");
            }
            else { this._city = value; }
        }
    }
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

    public string PrintDoctorToScript()
    {
        string print = Name + "\n" + HealthCentre + "\n" + AddressLineOne + "\n" + City + "\n" + Postcode;

        return print;
    }

}
