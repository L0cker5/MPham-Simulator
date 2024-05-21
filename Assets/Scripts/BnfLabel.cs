using System;

/// <summary>
/// Represents a labeled entity with a BNF number and a descriptive _label.
/// It provides validation to ensure that the number is within the range of 1 to 32 and that the _label is neither null nor greater than 185 characters.
/// This class includes constructors for initializing the fields and properties for getting and setting the values with appropriate validation.
/// </summary>
public class BnfLabel
{

    private int _number;
    private string _label;

    /// <summary>
    /// Initializes a new instance of the BnfLabel class.
    /// </summary>
    public BnfLabel() { }

    /// <summary>
    /// Initializes a new instance of the BnfLabel class with specified parameters.
    /// </summary>
    /// <param name="number">The number of the BNF _label</param>
    /// <param name="label">The text for the BNF Label</param>
    public BnfLabel(int number, String label) 
    {
        this.Number = number;
        this.Label = label;
    }

    //Must be between 1 and 32
    public int Number
    {
        get { return _number; }

        set
        {
            if (value <= 0 || value > 32)
            {
                throw new ArgumentException("BNF number out of range");
            }
            else { this._number = value; }
        }
    }

    //Connot be null and must be between 1 and 185 characters.
    public string Label
    {
        get { return _label; }

        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Label cannot be null");
            }
            else if (value.Length <= 0 || value.Length > 185)
            {
                throw new ArgumentOutOfRangeException("Invalid length of _label");
            }
            else { this._label = value; }
        }
    }
}
