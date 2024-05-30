using UnityEngine;

public class AccessCameraRig : MonoBehaviour
{
    public GameObject gameMenu;
    public OVRCameraRig cameraRig;
    public float x;
    public float y;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 headsetPosition = cameraRig.centerEyeAnchor.position;
        Quaternion headsetRotation = cameraRig.centerEyeAnchor.rotation;

        Debug.Log("Center eye Position " + headsetPosition);
        Debug.Log("Center eye Rotation " + headsetRotation);

        Vector3 menuPosition = new(headsetPosition.x + x,headsetPosition.y + y,headsetPosition.z);

        Instantiate(gameMenu, menuPosition, Quaternion.identity);
        Debug.Log("Center eye menu position " + menuPosition);

    }


    // Update is called once per frame
    void Update()
    {


    }
}
