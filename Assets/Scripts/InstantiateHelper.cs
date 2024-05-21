using System;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Helper class for the instantiateprefab classes
/// Provides functionality for positioning objects in the Unity scene based on the real-world environment captured by an OVRLocatable object, 
/// and also includes utilities for scene capture and permission management.
/// </summary>
public class InstantiateHelper
{
    public GameObject AnchorGameObject { get; }

    public InstantiateHelper(GameObject gameObject)
    {
        AnchorGameObject = gameObject;
    }

    /// <summary>
    /// Takes and anchors OVRLocatable components, accesses its positon and rotaion based on the cameras positon and rotaion. The position 
    /// and rotation are adjusted for the specific gameObject to be instantated and stores these updated values in the AnchorGameObject to be used.   
    /// </summary>
    /// <param name="locatable">The anchor with which the positon and rotation properaties are to be taken</param>
    /// <param name="camera"></param>
    public void SetTableLocation(OVRLocatable locatable, Camera camera = null)
    {
        if (!locatable.TryGetSceneAnchorPose(out var pose))
            return;

        var projectionCamera = camera == null ? Camera.main : camera;
        var position = pose.ComputeWorldPosition(projectionCamera);

        Quaternion rotation = (Quaternion)pose.ComputeWorldRotation(projectionCamera);

        // converts a Vector3 representation of the Quaternion using EulerAngles
        Vector3 newRot = rotation.eulerAngles;
        
        // Add a value to the relevent x,y,z to ammend the rotation 
        Vector3 updatedRot = new Vector3(newRot.x + 90, newRot.y - 90, newRot.z);
        
        // Convert the Vector3 back to a Quaternion using Quaternion.Euler
        rotation = Quaternion.Euler(updatedRot);

        if (position != null && rotation != null)
            AnchorGameObject.transform.SetPositionAndRotation(
                position.Value, rotation);
    }

    /// <summary>
    /// Takes and anchors OVRLocatable components, accesses its positon and rotaion based on the cameras positon and rotaion. The position 
    /// and rotation are adjusted for the specific gameObject to be instantated and stores these updated values in the AnchorGameObject to be used.   
    /// </summary>
    /// <param name="locatable">The anchor with which the positon and rotation properaties are to be taken</param>
    /// <param name="camera"></param>
    public void SetTableTwoLocation(OVRLocatable locatable, Camera camera = null)
    {
        if (!locatable.TryGetSceneAnchorPose(out var pose))
            return;

        var projectionCamera = camera == null ? Camera.main : camera;
        var position = pose.ComputeWorldPosition(projectionCamera);
        //var camRotation = pose.ComputeWorldRotation(projectionCamera);
        Quaternion rotation = (Quaternion)pose.ComputeWorldRotation(projectionCamera);

        // converts a Vector3 representation of the Quaternion using EulerAngles
        Vector3 newRot = rotation.eulerAngles;

        // Add a value to the relevent x,y,z to ammend the rotation 
        Vector3 updatedRot = new Vector3(newRot.x + 90, newRot.y - 90, newRot.z);

        // Convert the Vector3 back to a Quaternion using Quaternion.Euler
        rotation = Quaternion.Euler(updatedRot);

        if (position != null && rotation != null)
            AnchorGameObject.transform.SetPositionAndRotation(
                position.Value, rotation);
    }

    /// <summary>
    /// Takes and anchors OVRLocatable components, accesses its positon and rotaion based on the cameras positon and rotaion. The position 
    /// and rotation are adjusted for the specific gameObject to be instantated and stores these updated values in the AnchorGameObject to be used.   
    /// </summary>
    /// <param name="locatable">The anchor with which the positon and rotation properaties are to be taken</param>
    /// <param name="camera"></param>
    public void SetWallArtLocation(OVRLocatable locatable, Camera camera = null)
    {
        if (!locatable.TryGetSceneAnchorPose(out var pose))
            return;

        var projectionCamera = camera == null ? Camera.main : camera;
        var position = pose.ComputeWorldPosition(projectionCamera);
        //var camRotation = pose.ComputeWorldRotation(projectionCamera);
        Quaternion rotation = (Quaternion)pose.ComputeWorldRotation(projectionCamera);

        // converts a Vector3 representation of the Quaternion using EulerAngles
        Vector3 newRot = rotation.eulerAngles;

        // Add a value to the relevent x,y,z to ammend the rotation 
        Vector3 updatedRot = new Vector3(newRot.x, newRot.y - 90, newRot.z);

        // Convert the Vector3 back to a Quaternion using Quaternion.Euler
        rotation = Quaternion.Euler(updatedRot);

        if (position != null && rotation != null)
            AnchorGameObject.transform.SetPositionAndRotation(
                position.Value, rotation);
    }

    //  function for requesting Scene Capture.
    public static async Task<bool> RequestSceneCapture()
    {
        if (SceneCaptureRunning) return false;
        SceneCaptureRunning = true;

        var waiting = true;
        Action<ulong, bool> onCaptured = (id, success) => { waiting = false; };

        // subscribe, make non-blocking call, yield and wait
        return await Task.Run(() =>
        {
            OVRManager.SceneCaptureComplete += onCaptured;
            if (!OVRPlugin.RequestSceneCapture("", out var _))
            {
                OVRManager.SceneCaptureComplete -= onCaptured;
                SceneCaptureRunning = false;
                return false;
            }
            while (waiting) Task.Delay(200);
            OVRManager.SceneCaptureComplete -= onCaptured;
            SceneCaptureRunning = false;
            return true;
        });
    }
    private static bool SceneCaptureRunning = false; // single instance

    /// <summary>
    /// For requesting permission for scene data.
    /// </summary>
    public static void RequestScenePermission()
    {
        const string permission = "com.oculus.permission.USE_SCENE";
        if (!UnityEngine.Android.Permission.HasUserAuthorizedPermission(permission))
            UnityEngine.Android.Permission.RequestUserPermission(permission);
    }
}
