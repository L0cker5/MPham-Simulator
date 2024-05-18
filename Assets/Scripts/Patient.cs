using System;

public class Patient
{

    private string _name;
    private string _address;
    private string _city;
    private DateTime _dateOfBirth;

    public Patient() { }

    public Patient(String name, String address, String city, DateTime dateOfBirth)
    {
        this.Name = name;
        this.Address = address;
        this.City = city;
        this.DateOfBirth = dateOfBirth;
    }

    public string Name
    {
        get { return _name; }
        set 
        {
            if (value == null)
            {
                throw new ArgumentNullException("Patient name cannot be null");
            } 
            else if (value.Length <= 0 || value.Length > 50)
            {
                throw new ArgumentException("Invalid length of patient name");
            }
            else { this._name = value; }
        }
    }

    public string Address
    {
        get { return _address; }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Patient address cannot be null");
            }
            else if (value.Length <= 0 || value.Length > 50)
            {
                throw new ArgumentException("Invalid length of patient address");
            }
            else { this._address = value; }
        }
    }

    public string City
    {
        get { return _city; }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Patient city cannot be null");
            }
            else if (value.Length <= 0 || value.Length > 50)
            {
                throw new ArgumentException("Invalid length of patient city");
            }
            else { this._city = value; }
        }
    }

    public DateTime DateOfBirth
    {
        get { return _dateOfBirth; }
        set { _dateOfBirth = value; }
    }

    public string PrintPatientToScript()
    {
        string print = Name + "\n" + Address + "\n" + City;

        return print;
    }

}
