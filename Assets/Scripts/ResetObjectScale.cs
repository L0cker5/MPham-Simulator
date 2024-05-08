using Oculus.Interaction.HandGrab;
using System.Linq;
using UnityEngine;

public class ResetObjectScale : MonoBehaviour
{

    [SerializeField]
    private HandGrabInteractable _interactable;

    private Vector3 _scale;

    void Awake()
    {
        _scale = transform.localScale;
        Debug.Log("Scale : " +  _scale);
    }

    // Update is called once per frame
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
