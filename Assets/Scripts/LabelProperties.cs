using Oculus.Interaction.HandGrab;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

/// <summary>
/// Attached to a label prefab. Sets the information to be stored as variables and displaed on the prescription label when printed 
/// </summary>
public class LabelProperties : MonoBehaviour
{
    [SerializeField] 
    private TMP_Text _patientNameText, _todaysDateText, 
    _medicationText, _frequencyText, _bnfText;

    private List<BnfLabel> _bnfData;

    public string patientName, todaysDate, medicationName,
    doseage, frequency, bnfLabel;

    public StrengthUnit strengthUnit;
    public MedicationType medicationType;

    public float strength;

    public int quantity;

    [SerializeField]
    private HandGrabInteractable _interactable;

    public GameObject prescription;

    void Awake()
    {
        CheckForBnf();
        

        _patientNameText.text = PatientName;
        _todaysDateText.text = TodaysDate;
        _medicationText.text = Quantity + " " + MedicationName + " " + Strength + " " + StrengthUnit + " " + MedicationType;
        _frequencyText.text = "Take " + Dosage.ToUpper() + " " + Frequency;

    }

    /// <summary>
    /// Reads from the bnflabels.csv and stores the information in a list. 
    /// Checks the current prescription to be dispensed and takes the string data from the BnfLabel field. 
    /// If what is returend is blank it will print an empty string as there is no relevent BNFlabel to be 
    /// printed. If values are returned it splits the information on ";" storing the values as strings. 
    /// The strings are parsed into ints. If the int value is between 21 & 28 then this information needs 
    /// to be displayed on the label therfore the string stored at bnf.label is returned and printed onto 
    /// the prescription label.
    /// </summary>
    private void CheckForBnf()
    {

        prescription = GameObject.Find("Prescription");

        PrescriptionProperties prescriptionProperties = new PrescriptionProperties();
        prescriptionProperties = prescription.GetComponentInChildren<PrescriptionProperties>();

        string bnfLabels = prescriptionProperties.prescription.BnfLabels;

        if (bnfLabels.Length <= 0)
        {
            _bnfText.text = "";
        }
        else
        {

            // String separating characters
            string[] separatingStrings = { ";", ";;" };

            //creates a string array "numbers" by spliting on the chosen characters also removing empty entries
            string[] numbers = bnfLabels.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);

            int i = 0;
            // iterates through each element in the numbers array, using TryParse if the string is an int
            // it stores it to the 'a' int[]
            int[] a = (from s in numbers where int.TryParse(s, out i) select i).ToArray();

            foreach( int n in a )
            {
                if (n >= 21 && n <= 28)
                {
                    _bnfData = ReadCSV.ReadBnfData();
                    //Debug.Log("BNF Labels: " + _bnfData.Count);
                    //foreach (var bnfData in _bnfData)
                    //{
                    //Debug.Log("BNF: " + bnfData.Label);
                    //}
                    int labelNum = 0;
                    labelNum = n;
                    Debug.Log("BNF Labels num : " + labelNum);

                    BnfLabel bnf = _bnfData.Find(b => b.Number.Equals(labelNum));

                    _bnfText.text = bnf.Label;
                }

            }

        }
        Debug.Log("BNF Labels: " +  bnfLabels + " Length " + bnfLabels.Length);
        
    }

    public string PatientName
    {
        get { return patientName; }
        set { patientName = value; }
    }

    public string TodaysDate
    {
        get { return todaysDate; }
        set { todaysDate = value; }
    }

    public string MedicationName
    {
        get { return medicationName; }
        set { medicationName = value; }
    }

    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }
    public float Strength
    {
        get { return strength; }
        set { strength = value; }
    }

    public StrengthUnit StrengthUnit
    {
        get { return strengthUnit; }
        set { strengthUnit = value; }
    }

    public MedicationType MedicationType
    {
        get { return medicationType; }
        set { medicationType = value; }
    }
    public string Dosage
    {
        get { return doseage; }
        set { doseage = value; }
    }

    public string Frequency
    {
        get { return frequency; }
        set { frequency = value;}
    }

    public string BnfLabel
    {
        get { return bnfLabel; }
        set { bnfLabel = value; }
    }

}
