using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionKeyboard : MonoBehaviour
{
    [SerializeField]
    private OVRVirtualKeyboard keyboardObject;

    // Start is called before the first frame update
    void Start()
    {
        //keyboardObject = GetComponent<OVRVirtualKeyboard>();
        //keyboardObject.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        keyboardObject = OVRVirtualKeyboard.FindObjectOfType<OVRVirtualKeyboard>();

        Vector3 drawerPosition = transform.position;
        Quaternion drawerRotation = transform.rotation;

        //keyboardObject.enabled = true;
        float xVal = .05f;

        Vector3 newDrawerPosition = drawerPosition + (Vector3.up * xVal);
        Vector3 drawerRot = drawerRotation.eulerAngles;

        //Vector3 newDrawerRotation = new Vector3(drawerRot.x, drawerRot.y - 90, drawerRot.z);

        drawerRotation = Quaternion.Euler(drawerRot.x + 70, drawerRot.y - 90, drawerRot.z);

        keyboardObject.transform.SetPositionAndRotation(newDrawerPosition, drawerRotation);
    }

    //public void UpdateDrawerPosition()
    //{
    //    keyboardObject = OVRVirtualKeyboard.FindObjectOfType<OVRVirtualKeyboard>();

    //    Vector3 drawerPosition = transform.position;
    //    Quaternion drawerRotation = transform.rotation;

    //    keyboardObject.enabled = true;
    //    float xVal = .4f;

    //    Vector3  newDrawerPosition = drawerPosition + (Vector3.up * xVal);
    //    Vector3 drawerRot = drawerRotation.eulerAngles;

    //    Vector3 newDrawerRotation = new Vector3 (drawerRot.x, drawerRot.y - 90 , drawerRot.z);

    //    drawerRotation = Quaternion.Euler(drawerRot.x, drawerRot.y - 90, drawerRot.z);

    //    keyboardObject.transform.SetPositionAndRotation(newDrawerPosition, drawerRotation);

    //}
}
