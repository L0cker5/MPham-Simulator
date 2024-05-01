using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class GetActiveToggle : MonoBehaviour
{
    [SerializeField]
    private Toggle toggle;

    [SerializeField]
    private TMP_Text toggleText;


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
        
        if (toggle.isOn) 
        { 
        Debug.Log("Toggle " + toggleText.text + " active");
        ComputerManager.instance.toggle1Text = toggleText;
        }
    }
}
