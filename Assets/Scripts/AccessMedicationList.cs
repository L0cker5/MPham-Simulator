using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessMedicationList : MonoBehaviour
{
    
    //IEnumerator Start()
    //{
    //    rc = GetComponent<ReadCSV>();
    //    yield return new WaitForEndOfFrame();
    //    foreach(var s in rc.medications)
    //        Debug.Log("scriptItems "+ s.scriptItems);
    //}

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
