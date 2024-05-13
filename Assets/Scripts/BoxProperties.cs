using UnityEngine;

public class BoxProperties : MonoBehaviour
{

    public GameObject medsBox;

    [SerializeField]
    private string _name;

    [SerializeField]
    private float _strength;

    public string Name
    {
        get { return _name; }
    }

    public float Strength
    {
        get { return _strength; }
    }

    public string StrengthWithMg
    {
        get
        {
            string strengthWMg = _strength.ToString() + "mg";
            return strengthWMg;
        }
    }

    private void Start()
    {
        Debug.Log("Random Box Meds Name: " + Name + " Length: " + Name.Length);
    }

}
