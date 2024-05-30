using UnityEngine;

/// <summary>
/// attached to the _medication _box to store values for the name of the specific _medication and its strength
/// values are set in unity via the components section.
/// </summary>
public class BoxProperties : MonoBehaviour
{
    //public GameObject medsBox;

    [SerializeField]
    private string _name;

    [SerializeField]
    private float _strength;

    // Gets the _medication name
    public string Name
    {
        get { return _name; }
    }

    // Gets the _medication strength
    public float Strength
    {
        get { return _strength; }
    }

    // Gets the _medication strength with "mg" added to the string.
    // unused method due to the requirement of different possible units of measurement e.g kg, mcg etc
    // Now stored separate as enum in StrenthUnit.cs.
    public string StrengthWithMg
    {
        get
        {
            string strengthWMg = _strength.ToString() + "mg";
            return strengthWMg;
        }
    }
}
