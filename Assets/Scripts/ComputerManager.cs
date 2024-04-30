using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ComputerManager : MonoBehaviour
{
    [SerializeField] TMP_Text text1, text2;

    TMP_InputField inputField;

    [SerializeField] GameObject label;
    [SerializeField] private Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PrintLabel()
    {
        Vector3 position = spawnPoint.position;
        Quaternion rotation = spawnPoint.rotation;
        Debug.Log("Label Printed");
        LabelProperties labelProperties = label.GetComponent<LabelProperties>();
        labelProperties.Frequency = text2.text;
        labelProperties.MedicationName = text1.text;
        Instantiate(label, position, rotation);
        Debug.Log("Label Printed");

    }

}
