using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildVector : MonoBehaviour
{
    public Vector3 GetShelfPos(OVRLocatable.TrackingSpacePose pose)
    {
        Vector3? getShelfPos = pose.Position;

        float shelfXPos = getShelfPos.Value.x;
        float shelfYPos = getShelfPos.Value.y;
        float shelfZPos = getShelfPos.Value.z;

        Vector3 newShelfPos = new(shelfXPos, shelfYPos, shelfZPos);

        return newShelfPos;
    }

}
