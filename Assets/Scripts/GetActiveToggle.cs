using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GetActiveToggle : MonoBehaviour
{
    [SerializeField]
    private Toggle toggle;

    [SerializeField]
    private TMP_Text toggleText;

    private readonly string medicationNameTag = "Medication Name Toggle";
    private readonly string strengthUnitTag = "Strength Unit Toggle";
    private readonly string medicationTypeTag = "Medication Type Toggle";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleChanged()
    {
        
        if (toggle.isOn && toggle.CompareTag(medicationNameTag)) 
        { 
        Debug.Log("Toggle Tag " + toggleText.text + " active");
        
        ComputerManager.instance.medicationName = toggleText;
        }
        else if (toggle.isOn && toggle.CompareTag(strengthUnitTag))
        {
            Debug.Log("Toggle Tag " + toggleText.text + " active");

            ComputerManager.instance.strengthUnit = toggleText;
        }
        else if (toggle.isOn && toggle.CompareTag(medicationTypeTag))
        {
            Debug.Log("Toggle Tag " + toggleText.text + " active");

            ComputerManager.instance.medicationType = toggleText;
        }
    }
}
