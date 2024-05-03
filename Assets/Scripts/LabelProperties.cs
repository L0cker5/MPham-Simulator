using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using System.Linq;
using TMPro;
using UnityEngine;

public class LabelProperties : MonoBehaviour
{
    [SerializeField] 
    private TMP_Text patientNameText, todaysDateText, 
    medicationText, frequencyText;

    public string patientName, todaysDate, medicationName, quantity, strength,
    strengthUnit, medicationType, doseage, frequency;
    
    private bool grabInteraction;

    [SerializeField]
    private HandGrabInteractable _interactable;

    //public LabelProperties(string name, string freq)
    //{
    //    //this.medicationName = name;
    //    //this.frequency = freq;
    //    medicationName = name;
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

    public string Quantity
    {
        get { return quantity; }

        set { quantity = value; }
    }
        public string Strength
    {
        get { return strength; }

        set { strength = value; }
    }

    public string StrengthUnit
    {
        get { return strengthUnit; }

        set { strengthUnit = value; }
    }

    public string MedicationType
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
        patientNameText.text = patientName;
        todaysDateText.text = todaysDate;
        medicationText.text = quantity + " " + medicationName + " " + strength + " " + strengthUnit + " " + medicationType;
        frequencyText.text = "Take " + doseage.ToUpper() + " " + frequency;
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
