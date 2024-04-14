using UnityEngine;

public class LabelProperties : MonoBehaviour
{
    private string _medicationName = "OxyNorm";
    private string _frequency = "every 4-6 hours";


    public LabelProperties(string name, string freq)
    {
        this._medicationName = name;
        this._frequency = freq;
        //_medicationName = _name;
        //_frequency = freq;
    }

    public string MedicationName
    {
        get { return _medicationName; }

        set { _medicationName = value; }
    }

    public string Frequency
    {
        
        // changes to how you grab data
        get { return _frequency; }
        // restrict changes to the data 
        set { _frequency = value;}
    }


    // Start is called before the first frame update
    void Start()
    {
        //LabelProperties lProps = new LabelProperties("John", "never");

        //string lName = lProps.MedicationName;
        //string lFreq = lProps.Frequency;


        //Debug.Log("Label Properties " + lName + " " +  lFreq);
        Debug.Log("Label Properties " + MedicationName + " " + Frequency);

        string lName = MedicationName = "Bob";
        string lFreq = Frequency = "Always";


        Debug.Log("Label Properties " + lName + " " + lFreq);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
