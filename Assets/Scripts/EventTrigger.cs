using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("Label") && other.gameObject.CompareTag("Medication"))
        //{
        //    Debug.Log("Entering Trigger ");
        //}

        if (other.gameObject.CompareTag("Label"))
        {
            Debug.Log("Entering Trigger ");
        }

        //Debug.Log("Object with Tag entered " + other.gameObject.tag);

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Label"))
        {
            Debug.Log("Staying in Trigger ");
        }

        //Debug.Log("Object with Tag stayed " + other.gameObject.tag);

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Label"))
        {
            Debug.Log("Exiting Trigger ");
        }

        //Debug.Log("Object with Tag exited " + other.gameObject.tag);

    }

}
