using TMPro;
using UnityEngine;

public class LabelProperties : MonoBehaviour
{
    [SerializeField] TMP_Text text1, text2;

    public string medicationName = null;
    public string frequency = null;


    //public LabelProperties(string name, string freq)
    //{
    //    //this.medicationName = name;
    //    //this.frequency = freq;
    //    medicationName = name;
    //    frequency = freq;
    //}

    public string MedicationName
    {
        get { return medicationName; }

        set { medicationName = value; }
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
        text1.text = medicationName;
        text2.text = frequency;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
