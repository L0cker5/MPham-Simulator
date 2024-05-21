using System;

/// <summary>
/// Represents a patient with properties including name, address, city and dateOfBirth
/// It includes validation for these properties to ensure they fall within acceptable ranges and constraints.
/// </summary>
public class Patient
{

    private string _name;
    private string _address;
    private string _city;
    private DateTime _dateOfBirth;


    /// <summary>
    /// Initializes a new instance of the Patient class.
    /// </summary>
    public Patient() { }

    /// <summary>
    /// Initializes a new instance of the Patient class with specified parameters.
    /// </summary>
    /// <param name="name">The name of the patient.</param>
    /// <param name="address">The address of the patient.</param>
    /// <param name="city">The city of the patient.</param>
    /// <param name="dateOfBirth">The date of birth of the patient.</param>
    public Patient(String name, String address, String city, DateTime dateOfBirth)
    {
        this.Name = name;
        this.Address = address;
        this.City = city;
        this.DateOfBirth = dateOfBirth;
    }

    // Must not be null, must be between 1 and 50 characters.
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

    // Must not be null, must be between 1 and 50 characters.
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

    // Must not be null, must be between 1 and 50 characters.
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

    // Returns a formatted string representation of the patient name and address details.
    public string PrintPatientToScript()
    {
        string print = Name + "\n" + Address + "\n" + City;

        return print;
    }

}
