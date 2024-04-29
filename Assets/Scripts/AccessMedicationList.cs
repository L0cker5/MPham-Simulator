using System.Collections.Generic;
using UnityEngine;

public class AccessMedicationList : MonoBehaviour
{
    
    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        List<Medication> medications = new List<Medication>();

        medications = ReadCSV.medications;

        Debug.Log("meds length " +  medications.Count);

        foreach (Medication m in medications)
        {
            Debug.Log("meds " + m.scriptItems);
        }
    }
}
