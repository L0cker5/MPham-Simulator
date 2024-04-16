using UnityEngine;

public class BoxProperties : MonoBehaviour
{

    public GameObject medsBox;
    private int _strength = 50;

    public string Name
    {
        get
        {
            string boxName = medsBox.name;
            return boxName;
        }
    }


    public int Strength
    {
        get
        { return _strength; }
    }

    public string StrengthWithMg
    {
        get
        {
            string strengthWMg = _strength.ToString() + "mg";
            return strengthWMg;
        }
    }


    // Start is called before the first frame update
    void Start()
    {

        //Debug.Log("Box Properties " + Name + " " + StrengthWithMg);

    }

}
