using System;

public class BnfLabel
{

    private int _number;
    private string _label;
    
    public BnfLabel() { }

    public BnfLabel(int number, String label) 
    {
        this.Number = number;
        this.Label = label;
    }

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
                throw new ArgumentOutOfRangeException("Invalid length of label");
            }
            else { this._label = value; }
        }
    }
}
