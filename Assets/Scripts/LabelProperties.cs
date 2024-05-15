using Oculus.Interaction.HandGrab;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class LabelProperties : MonoBehaviour
{
    [SerializeField] 
    private TMP_Text patientNameText, todaysDateText, 
    medicationText, frequencyText, bnfText;

    private List<BnfLabel> bnfData;

    public string patientName, todaysDate, medicationName,
    doseage, frequency, bnfLabel;

    public StrengthUnit strengthUnit;
    public MedicationType medicationType;

    public float strength;

    public int quantity;

    //private bool grabInteraction;

    [SerializeField]
    private HandGrabInteractable _interactable;

    public GameObject prescription;

    void Awake()
    {
        CheckForBnf();
        
        //patientNameText.text = PatientName;
        //todaysDateText.text = TodaysDate;
        //medicationText.text = Quantity + " " + MedicationName + " " + Strength + " " + StrengthUnit + " " + MedicationType;
        //frequencyText.text = "Take " + Dosage.ToUpper() + " " + Frequency;

    }

    private void CheckForBnf()
    {
        bnfData = ReadCSV.readBnfData();
        
        Debug.Log("BNF Labels: " + bnfData.Count);

        foreach (var bnfData in bnfData)
        {
            Debug.Log("BNF: " + bnfData.Label);
        }
        

        prescription = GameObject.Find("Prescription");

        PrescriptionProperties prescriptionProperties = new PrescriptionProperties();
        prescriptionProperties = prescription.GetComponentInChildren<PrescriptionProperties>();

        string bnfLabels = prescriptionProperties.prescription.BnfLabels;

        if (bnfLabels.Length <= 0)
        {
            bnfText.text = "Empty";
        }
        else
        {
            // String separating characters
            string[] separatingStrings = { ";", ";;" };

            //string BNFLabels = "2;20;,;;f;2null;'2null';25";

            //creates a string array "words" by spliting on the chosen characters also removing empty entries
            string[] words = bnfLabels.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);

            int i = 0;
            // iterates through each element s in the words array, using TryParse if the string is an int
            // it stores it to the 'a' int[]
            int[] a = (from s in words where int.TryParse(s, out i) select i).ToArray();

            foreach( int n in a )
            {
                if (n >= 21 && n <= 28)
                {
                    int labelNum = 0;
                    labelNum = n;
                    Debug.Log("BNF Labels num : " + labelNum);

                    BnfLabel bnf = bnfData.Find(b => b.Number.Equals(labelNum));

                    bnfText.text = bnf.Label;
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
        // changes to how you grab data
        get { return frequency; }
        // restrict changes to the data 
        set { frequency = value;}
    }

    public string BnfLabel
    {
        get { return bnfLabel; }
        // restrict changes to the data 
        set { bnfLabel = value; }

    }

}
