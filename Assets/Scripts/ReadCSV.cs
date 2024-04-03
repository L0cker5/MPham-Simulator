using System.Collections.Generic;
using UnityEngine;

public class ReadCSV : MonoBehaviour
{
    
    public static List<Medication> medications = new List<Medication>();
   
    // Start is called before the first frame update
    void Start()
    {
        TextAsset medicationData = Resources.Load<TextAsset>("medicationdata");

        string[] data = medicationData.text.Split(new char[] { '\n' });

        //Debug.log(data.length);
        
        for (int i = 1; i < data.Length - 1; i++)
        {
            string[] row = data[i].Split(new char[] { ',' });
            
            // if the scriptItems field is empty skip
            if (row[1] != "")
            {
            Medication m = new Medication();
            //if there is no data in the row it will leave it blank
            int.TryParse(row[0], out m.id);
            m.scriptItems = row[1];
            m.errors_Actions1 = row[2];
            m.general = row[3];
            int.TryParse(row[4], out m.BNFLabels);
            m.codes_POR = row[5];

            medications.Add(m);
            }
        }

        //foreach (Medication m in medications) 
        //{
        //    Debug.Log("medication " + m.scriptItems);
        //}

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
