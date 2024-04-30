using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GetToggleData : MonoBehaviour
{
    [SerializeField]
    private Toggle selectedToggle;
    
    [SerializeField] private ToggleGroup toggleGroup;

    void Awake()
    {
        if (toggleGroup == null) toggleGroup = GetComponent<ToggleGroup>();
    }

    public void LogSelectedToggle()
    {

        selectedToggle = toggleGroup.ActiveToggles().FirstOrDefault();
        if (selectedToggle != null)
            Debug.Log(selectedToggle, selectedToggle);
    }
}
