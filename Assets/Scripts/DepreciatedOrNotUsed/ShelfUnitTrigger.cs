using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShelfUnitTrigger : MonoBehaviour
{
    private readonly string _box = "Box";
    private readonly string _medicationBox = "Medication";

    // Parent object of the _box prefab
    //private GameObject parentObject;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(_box))
        {
            GameObject parentObject = GameObject.FindGameObjectWithTag(_medicationBox);
            Debug.Log("Parnet Object: " + parentObject.ToString());
            parentObject.transform.SetParent(null);

        }
    }
}
