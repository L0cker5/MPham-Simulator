using Oculus.Interaction.HandGrab;
using TMPro;
using UnityEngine;

public class LabelProperties : MonoBehaviour
{
    [SerializeField] 
    private TMP_Text patientNameText, todaysDateText, 
    medicationText, frequencyText;

    public string patientName, todaysDate, medicationName,
    doseage, frequency;

    public StrengthUnit strengthUnit;
    public MedicationType medicationType;

    public float strength;

    public int quantity;

    private bool grabInteraction;

    [SerializeField]
    private HandGrabInteractable _interactable;

    //public LabelProperties(string name, string freq)
    //{
    //    //this._medicationName = name;
    //    //this.frequency = freq;
    //    _medicationName = name;
    //    frequency = freq;
    //}

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


    // Start is called before the first frame update
    void Awake()
    {
        patientNameText.text = PatientName;
        todaysDateText.text = TodaysDate;
        medicationText.text = Quantity + " " + MedicationName + " " + Strength + " " + StrengthUnit + " " + MedicationType;
        frequencyText.text = "Take " + Dosage.ToUpper() + " " + Frequency;
    }

    // Update is called once per frame
    void Start()
    {
        //GrabInteractable _interactable = transform.GetComponent<GrabInteractable>();

        //var grab = _interactable.Interactors.FirstOrDefault<HandGrabInteractor>();

        ////grabInteraction = _interactable.ResetGrabOnGrabsUpdated;
        
        ////Debug.Log("Grab " + grab);

        //if (grab == null) 
        //{
        //    Debug.Log("Grab released");
        //} 
        //else if (grab != null)
        //{
        //    Debug.Log("Grab grabed");
        //}
    }
}
