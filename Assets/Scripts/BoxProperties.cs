using UnityEngine;

public class BoxProperties : MonoBehaviour
{

    public GameObject medsBox;
    // private string _name;
    public int strength;

    //public BoxProperties(string _name, int strength)
    //{
    //    this._name = _name;
    //    this.strength = strength;
    //}

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
        { return strength; }
    }

    public string StrengthWithMg
    {
        get
        {
            string strengthWMg = strength.ToString() + "mg";
            return strengthWMg;
        }
    }


    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("Box Properties " + Name + " " + StrengthWithMg);

    }

}
