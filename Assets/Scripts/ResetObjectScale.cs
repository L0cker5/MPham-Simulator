using Oculus.Interaction.HandGrab;
using System.Linq;
using UnityEngine;

/// <summary>
/// Attached to scalabled object. Stores the parent objects scale on instantiation. When the object is 
/// picked up and resized/rescaled and then dropped the object returns to its original scale.
/// </summary>
public class ResetObjectScale : MonoBehaviour
{

    [SerializeField]
    private HandGrabInteractable _interactable;

    private Vector3 _scale;

    /// <summary>
    /// Gets the obejcts scale on instantiation
    /// </summary>
    void Awake()
    {
        _scale = transform.localScale;
        Debug.Log("Scale : " +  _scale);
    }

    /// <summary>
    /// Listens for the object to be grabbed from the HandGrabInteractor. If the object is not 
    /// being grabbed the grab var is set to null resetting the objects scale to its original values
    /// </summary>
    void Update()
    {
        var grab = _interactable.Interactors.FirstOrDefault<HandGrabInteractor>();

        if (grab == null)
        {
            transform.localScale = _scale;
            Debug.Log("Grab released");
        }
    }
}
