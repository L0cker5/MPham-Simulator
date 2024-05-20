using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class CheckRoomModel : MonoBehaviour
{
    [SerializeField]
    private GameObject startButton;

    [SerializeField]
    private GameObject disabledStartButton;

    //private bool startButtonActive = true;
    //private bool disabledButtonActive = false;

    // UI text GameObjects and links to anchor prefabs GameObjects
    public TMP_Text textmeshpro_ObjectA;
    public GameObject prefab_ObjectA;
    public TMP_Text textmeshpro_ObjectB;
    public GameObject prefab_ObjectB;
    public TMP_Text textmeshpro_ObjectC;
    public GameObject prefab_ObjectC;

    // Constants 
    private readonly string _activeText = "Active";
    private readonly string _missingText = "Missing";

    private readonly int _defaultTextSize = 36;
    private readonly int _errorTextSize = 10;

    private readonly Color _activeTextColor = Color.green;
    private readonly Color _errorTextColor = Color.yellow;
    private readonly Color _missingTextColor = Color.red;

    async void Start()
    {

        _ = new List<OVRAnchor>();

        List<OVRAnchor> anchors = await GetAnchors();
        
        Debug.Log("Anchors main" + anchors.Count);

        await Check3DAnchor(anchors, OVRSceneManager.Classification.Table, textmeshpro_ObjectA, prefab_ObjectA);
        await Check2DAnchor(anchors, OVRSceneManager.Classification.WallArt, textmeshpro_ObjectB, prefab_ObjectB);
        await Check3DAnchor(anchors, OVRSceneManager.Classification.Table, textmeshpro_ObjectC, prefab_ObjectC);

    }

    async Task<List<OVRAnchor>> GetAnchors()
    {
        
        var anchors = new List<OVRAnchor>();
        await OVRAnchor.FetchAnchorsAsync<OVRRoomLayout>(anchors);

        Debug.Log("Anchors get" + anchors.Count);

        // get the component to access its data
        var room = anchors.First();

        room.TryGetComponent(out OVRAnchorContainer container);

        // access all child anchors
        await container.FetchChildrenAsync(anchors);

        return anchors;

    }
    async Task Check3DAnchor(List<OVRAnchor> anchors, string anchorLabel, TMP_Text obj, GameObject prefab)
    {

        Debug.Log("Anchors table 2" + anchors.Count);

        //
        foreach (var roomAnchor in anchors)
        {
 
            if (roomAnchor.TryGetComponent(out OVRSemanticLabels label) && 
                label.Labels.Contains(anchorLabel))
            {
                startButton.SetActive(true);
                disabledStartButton.SetActive(false);

                string activeText = _activeText;
                var activeTextColor = _activeTextColor;
                float activeTextSize = _defaultTextSize;

                // Get access to the bounding plane information of the anchor
                roomAnchor.TryGetComponent(out OVRBounded2D bounds);
                var bbox = bounds.BoundingBox;

                // Get the width and height of the 2d plane of the anchor
                // if anchor object also has a 3d plane e.g table the 2d plane of the anchor
                // refers to what would be the table top and the height dimenson refers to the depth of the table
                float anchorHeight = bbox.height;
                float anchorWidth = bbox.width;

                Debug.Log("Dimensions of the anchor are, Height: " + anchorHeight
                    + ", Width: " + anchorWidth);

                // creates an instance "test" from the TestProps script and access the TestProps script attached to the prefab (GameObject)
                PrefabProperties prefabProps = prefab.GetComponent<PrefabProperties>();

                var b = prefab.transform.Find("BoundaryBox");
                
                float height = b.localScale.y;
                float width = b.localScale.z;
                float depth = b.localScale.x;

                Debug.Log("Dimensions of the object are, Height: " + height 
                    + ", Width: " + width + ", Depth: " + depth);

                if (width > anchorWidth && depth > anchorHeight) {
                    activeText = "The dimensions of the anchor are too small and need to be atleast " + width.ToString("0.00") 
                        + "m wide & " + depth.ToString("0.00")+ "m deep.";
                    activeTextSize = _errorTextSize;
                    activeTextColor = _errorTextColor;
                } 
                else if (depth > anchorHeight)
                {
                    activeText = "The " + anchorLabel + " anchor depth " + anchorHeight.ToString("0.00") + "m is to small." +
                        " The anchor needs to be at least " + depth.ToString("0.00") + "m.";
                    activeTextSize = _errorTextSize;
                    activeTextColor = _errorTextColor;
                }
                else if (width > anchorWidth)
                {
                    activeText = "The " + anchorLabel + " anchor width " + anchorWidth.ToString("0.00") + "m is to small." +
                        " The anchor needs to be at least " + width.ToString("0.00") + "m.";
                    activeTextSize = _errorTextSize;
                    activeTextColor = _errorTextColor;
                }
                obj.text = activeText;
                obj.color = activeTextColor;
                obj.fontSize = activeTextSize;
                return;
            } 
            else
            {
                obj.text = _missingText;
                obj.color = _missingTextColor;
                //DisableStartButton();
                startButton.SetActive(false);
                disabledStartButton.SetActive(true);
            }

        }
        await Task.WhenAll();
    }


    async Task Check2DAnchor(List<OVRAnchor> anchors, string anchorLabel, TMP_Text obj, GameObject prefab)
    {

        Debug.Log("Anchors table 2" + anchors.Count);

        //
        foreach (var roomAnchor in anchors)
        {

            if (roomAnchor.TryGetComponent(out OVRSemanticLabels label) &&
                label.Labels.Contains(anchorLabel))
            {
                startButton.SetActive(true);
                disabledStartButton.SetActive(false);

                string activeText = _activeText;
                var activeTextColor = _activeTextColor;
                float activeTextSize = _defaultTextSize;

                // Get access to the bounding plane information of the anchor
                roomAnchor.TryGetComponent(out OVRBounded2D bounds);
                var bbox = bounds.BoundingBox;

                // Get the width and height of the 2d plane of the anchor
                // if anchor object also has a 3d plane e.g table the 2d plane of the anchor
                // refers to what would be the table top and the height dimenson refers to the depth of the table
                float anchorHeight = bbox.height;
                float anchorWidth = bbox.width;

                Debug.Log("Dimensions of the anchor are, Height: " + anchorHeight
                    + ", Width: " + anchorWidth);

                // creates an instance "test" from the TestProps script and access the TestProps script attached to the prefab (GameObject)
                PrefabProperties prefabProps = prefab.GetComponent<PrefabProperties>();

                var b = prefab.transform.Find("BoundaryBox");

                float height = b.localScale.y;
                float width = b.localScale.z;
                float depth = b.localScale.x;

                Debug.Log("Dimensions of the object are, Height: " + height
                    + ", Width: " + width + ", Depth: " + depth);

                if (width > anchorWidth && height > anchorHeight)
                {
                    activeText = "The dimensions of the anchor are too small and need to be atleast " + width.ToString("0.00")
                        + "m wide & " + height.ToString("0.00") + "m high.";
                    activeTextSize = _errorTextSize;
                    activeTextColor = _errorTextColor;
                }
                else if (height > anchorHeight)
                {
                    activeText = "The " + anchorLabel + " anchor height " + anchorHeight.ToString("0.00") + "m is to small." +
                        " The anchor needs to be at least " + height.ToString("0.00") + "m.";
                    activeTextSize = _errorTextSize;
                    activeTextColor = _errorTextColor;
                }
                else if (width > anchorWidth)
                {
                    activeText = "The " + anchorLabel + " anchor width " + anchorWidth.ToString("0.00") + "m is to small." +
                        " The anchor needs to be at least " + width.ToString("0.00") + "m.";
                    activeTextSize = _errorTextSize;
                    activeTextColor = _errorTextColor;
                }
                obj.text = activeText;
                obj.color = activeTextColor;
                obj.fontSize = activeTextSize;
                return;
            }
            else
            {
                obj.text = _missingText;
                obj.color = _missingTextColor;
                startButton.SetActive(false);
                disabledStartButton.SetActive(true);
                //DisableStartButton();
            }

        }
        await Task.WhenAll();
    }


    //private void DisableStartButton()
    //{
    //    // v is false disable startbutton and enable disabledStartButton

        
    //}

}
