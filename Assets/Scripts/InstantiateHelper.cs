using System;
using System.Threading.Tasks;
using UnityEngine;

public class InstantiateHelper
{
    public GameObject AnchorGameObject { get; }

    public InstantiateHelper(GameObject gameObject)
    {
        AnchorGameObject = gameObject;
    }

    public void SetTableLocation(OVRLocatable locatable, Camera camera = null)
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
    /// A wrapper function for requesting the Android
    /// permission for scene data.
    /// </summary>
    public static void RequestScenePermission()
    {
        const string permission = "com.oculus.permission.USE_SCENE";
        if (!UnityEngine.Android.Permission.HasUserAuthorizedPermission(permission))
            UnityEngine.Android.Permission.RequestUserPermission(permission);
    }
}
