using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

/// <summary>
/// Checks the current room model against the GameObject prefabs to be loaded 
/// into the scene to ensure that that virtual size of the anchor is big enough 
/// for the GameObject to occupy the space.e.g.loading the ComputerAndPrinter 
/// prefab onto a table that is too small.
/// </summary>
public class CheckRoomModel : MonoBehaviour
{
    [SerializeField]
    private GameObject _startButton;

    [SerializeField]
    private GameObject _disabledStartButton;

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

    private bool _objectAError = true;
    private bool _objectBError = true;
    private bool _objectCError = true;

    async void Start()
    {
        _startButton.SetActive(true);
        _disabledStartButton.SetActive(false);

        _ = new List<OVRAnchor>();

        List<OVRAnchor> anchors = await GetAnchors();
        
        //Debug.Log("Anchors main" + anchors.Count);

        await CheckTableAnchor(anchors, OVRSceneManager.Classification.Table, textmeshpro_ObjectA, prefab_ObjectA);
        await CheckWallArtAnchor(anchors, OVRSceneManager.Classification.WallArt, textmeshpro_ObjectB, prefab_ObjectB);
        await CheckTableTwoAnchor(anchors, OVRSceneManager.Classification.Table, textmeshpro_ObjectC, prefab_ObjectC);

        if (!_objectAError || !_objectBError || !_objectCError) 
        {
            _startButton.SetActive(false);
            _disabledStartButton.SetActive(true);
        }

    }


    /// <summary>
    /// Creates a list of all the anchors stored in the room model
    /// </summary>
    /// <returns> A list of room anchors</returns>
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

    /// <summary>
    /// Checks the dimesions width and depth of the prefabs BoundingBox against the dimensions 
    /// of the specificed anchor to ensure it can be loaded into the scene, if the 
    /// dimensions of the prefab are smaller "Active" is displayed. If there is no anchors in 
    /// the room model of the specified type "Missing" is displayed. If the dimensions of the 
    /// prefab are bigger that the anchor a corrisponding error message is displayed 
    /// </summary>
    /// <param name="anchors">List of anchors</param>
    /// <param name="anchorLabel">Semantic Classification of a anchor</param>
    /// <param name="obj">Text Mesh Pro textfield the relevent text is to be displaed in</param>
    /// <param name="prefab">The prefab GameObject to be compared with the anchors dimensions</param>
    /// <returns></returns>
    async Task CheckTableAnchor(List<OVRAnchor> anchors, string anchorLabel, TMP_Text obj, GameObject prefab)
    {
        var tableAnchors = new List<OVRAnchor>();
        OVRAnchor table; ;
        
        foreach (var roomAnchor in anchors)
        {
            if (roomAnchor.TryGetComponent(out OVRSemanticLabels label) &&
                    label.Labels.Contains(anchorLabel))
            {
                tableAnchors.Add(roomAnchor);
            }
        }

        if (tableAnchors.Count == 0)
        {
            obj.text = _missingText;
            obj.color = _missingTextColor;
            _objectAError = false;
        }
        else
        {
            table = tableAnchors[0];

            string activeText = _activeText;
            var activeTextColor = _activeTextColor;
            float activeTextSize = _defaultTextSize;

            // Get access to the bounding plane information of the anchor
            table.TryGetComponent(out OVRBounded2D bounds);
            var bbox = bounds.BoundingBox;

            // Get the width and height of the 2d plane of the anchor
            // if anchor object also has a 3d plane e.g table the 2d plane of the anchor
            // refers to what would be the table top and the height dimenson refers to the depth of the table
            float anchorHeight = bbox.height;
            float anchorWidth = bbox.width;

            var b = prefab.transform.Find("BoundaryBox");

            float width = b.localScale.z;
            float depth = b.localScale.x;

            if (width > anchorWidth && depth > anchorHeight)
            {
                activeText = "The dimensions of the anchor are too small and need to be atleast " + width.ToString("0.00")
                    + "m wide & " + depth.ToString("0.00") + "m deep.";
                activeTextSize = _errorTextSize;
                activeTextColor = _errorTextColor;
                _objectAError = false;
            }
            else if (depth > anchorHeight)
            {
                activeText = "The " + anchorLabel + " anchor depth " + anchorHeight.ToString("0.00") + "m is to small." +
                    " The anchor needs to be at least " + depth.ToString("0.00") + "m.";
                activeTextSize = _errorTextSize;
                activeTextColor = _errorTextColor;
                _objectAError = false;
            }
            else if (width > anchorWidth)
            {
                activeText = "The " + anchorLabel + " anchor width " + anchorWidth.ToString("0.00") + "m is to small." +
                    " The anchor needs to be at least " + width.ToString("0.00") + "m.";
                activeTextSize = _errorTextSize;
                activeTextColor = _errorTextColor;
                _objectAError = false;
            }
            obj.text = activeText;
            obj.color = activeTextColor;
            obj.fontSize = activeTextSize;
            return;
        }
        
        await Task.WhenAll();
    }

    /// <summary>
    /// checks the dimesions width and height of the prefabs BoundingBox against the dimensions 
    /// of the specificed anchor to ensure it can be loaded into the scene, if the dimensions 
    /// of the prefab are smaller "Active" is displayed. If there is no anchors in the room model 
    /// of the specified type "Missing" is displayed. If the dimensions of the prefab are bigger 
    /// that the anchor a corrisponding error message is displayed 
    /// </summary>
    /// <param name="anchors">List of anchors</param>
    /// <param name="anchorLabel">Semantic Classification of a anchor</param>
    /// <param name="obj">Text Mesh Pro textfield the relevent text is to be displaed in</param>
    /// <param name="prefab">The prefab GameObject to be compared with the anchors dimensions</param>
    /// <returns></returns>
    async Task CheckWallArtAnchor(List<OVRAnchor> anchors, string anchorLabel, TMP_Text obj, GameObject prefab)
    {
        var wallArtAnchors = new List<OVRAnchor>();
        OVRAnchor wallArt;

        foreach (var roomAnchor in anchors)
        {

            if (roomAnchor.TryGetComponent(out OVRSemanticLabels label) &&
                label.Labels.Contains(anchorLabel))
            {
                wallArtAnchors.Add(roomAnchor);
            }
        }


        if (wallArtAnchors.Count == 0 )
        {
            Debug.Log("Is NUll: " +  wallArtAnchors.Count);
            obj.text = _missingText;
            obj.color = _missingTextColor;
            _objectBError = false;
        }
        else
        {
            wallArt = wallArtAnchors[0];

            string activeText = _activeText;
            var activeTextColor = _activeTextColor;
            float activeTextSize = _defaultTextSize;

            // Get access to the bounding plane information of the anchor
            wallArt.TryGetComponent(out OVRBounded2D bounds);
            var bbox = bounds.BoundingBox;

            // Get the width and height of the 2d plane of the anchor
            // if anchor object also has a 3d plane e.g table the 2d plane of the anchor
            // refers to what would be the table top and the height dimenson refers to the depth of the table
            float anchorHeight = bbox.height;
            float anchorWidth = bbox.width;

            // Access the BoundaryBox of the prefab and get the height and width
            var b = prefab.transform.Find("BoundaryBox");
            float height = b.localScale.y;
            float width = b.localScale.z;

            if (width > anchorWidth && height > anchorHeight)
            {
                activeText = "The dimensions of the anchor are too small and need to be at least " + width.ToString("0.00")
                    + "m wide & " + height.ToString("0.00") + "m high.";
                activeTextSize = _errorTextSize;
                activeTextColor = _errorTextColor;
                _objectBError = false;
            }
            else if (height > anchorHeight)
            {
                activeText = "The " + anchorLabel + " anchor height " + anchorHeight.ToString("0.00") + "m is to small." +
                    " The anchor needs to be at least " + height.ToString("0.00") + "m.";
                activeTextSize = _errorTextSize;
                activeTextColor = _errorTextColor;
                _objectBError = false;
            }
            else if (width > anchorWidth)
            {
                activeText = "The " + anchorLabel + " anchor width " + anchorWidth.ToString("0.00") + "m is to small." +
                    " The anchor needs to be at least " + width.ToString("0.00") + "m.";
                activeTextSize = _errorTextSize;
                activeTextColor = _errorTextColor;
                _objectBError = false;
            }
            obj.text = activeText;
            obj.color = activeTextColor;
            obj.fontSize = activeTextSize;
            return;
        }
        await Task.WhenAll();
    }

    /// <summary>
    /// Checks the dimesions width and depth of the prefabs BoundingBox against the dimensions 
    /// of the specificed anchor to ensure it can be loaded into the scene, if the 
    /// dimensions of the prefab are smaller "Active" is displayed. If there is no anchors in 
    /// the room model of the specified type "Missing" is displayed. If the dimensions of the 
    /// prefab are bigger that the anchor a corrisponding error message is displayed 
    /// </summary>
    /// <param name="anchors">List of anchors</param>
    /// <param name="anchorLabel">Semantic Classification of a anchor</param>
    /// <param name="obj">Text Mesh Pro textfield the relevent text is to be displaed in</param>
    /// <param name="prefab">The prefab GameObject to be compared with the anchors dimensions</param>
    /// <returns></returns>
    async Task CheckTableTwoAnchor(List<OVRAnchor> anchors, string anchorLabel, TMP_Text obj, GameObject prefab)
    {
        var tableAnchors = new List<OVRAnchor>();
        OVRAnchor table;

        foreach (var roomAnchor in anchors)
        {
            if (roomAnchor.TryGetComponent(out OVRSemanticLabels label) &&
                    label.Labels.Contains(anchorLabel))
            {
                tableAnchors.Add(roomAnchor);
            }
        }

        if (tableAnchors.Count == 0 || tableAnchors.Count < 2 )
        {
            obj.text = _missingText;
            obj.color = _missingTextColor;
            _objectCError = false;
        }
        else
        {
            table = tableAnchors[1];

            string activeText = _activeText;
            var activeTextColor = _activeTextColor;
            float activeTextSize = _defaultTextSize;

            // Get access to the bounding plane information of the anchor
            table.TryGetComponent(out OVRBounded2D bounds);
            var bbox = bounds.BoundingBox;

            // Get the width and height of the 2d plane of the anchor
            // if anchor object also has a 3d plane e.g table the 2d plane of the anchor
            // refers to what would be the table top and the height dimenson refers to the depth of the table
            float anchorHeight = bbox.height;
            float anchorWidth = bbox.width;

            var b = prefab.transform.Find("BoundaryBox");

            float width = b.localScale.z;
            float depth = b.localScale.x;

            if (width > anchorWidth && depth > anchorHeight)
            {
                activeText = "The dimensions of the anchor are too small and need to be atleast " + width.ToString("0.00")
                    + "m wide & " + depth.ToString("0.00") + "m deep.";
                activeTextSize = _errorTextSize;
                activeTextColor = _errorTextColor;
                _objectCError = false;
            }
            else if (depth > anchorHeight)
            {
                activeText = "The " + anchorLabel + " anchor depth " + anchorHeight.ToString("0.00") + "m is to small." +
                    " The anchor needs to be at least " + depth.ToString("0.00") + "m.";
                activeTextSize = _errorTextSize;
                activeTextColor = _errorTextColor;
                _objectCError = false;
            }
            else if (width > anchorWidth)
            {
                activeText = "The " + anchorLabel + " anchor width " + anchorWidth.ToString("0.00") + "m is to small." +
                    " The anchor needs to be at least " + width.ToString("0.00") + "m.";
                activeTextSize = _errorTextSize;
                activeTextColor = _errorTextColor;
                _objectCError = false;
            }
            obj.text = activeText;
            obj.color = activeTextColor;
            obj.fontSize = activeTextSize;
            return;
        }

        await Task.WhenAll();
    }

}
