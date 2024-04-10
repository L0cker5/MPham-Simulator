using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class CheckRoomModel : MonoBehaviour
{
    // UI text GameObjects and links to anchor prefabs GameObjects
    public TMP_Text textmeshpro_ObjectA;
    public GameObject prefab_ObjectA;
    public TMP_Text textmeshpro_ObjectB;
    public GameObject prefab_ObjectB;
    public TMP_Text textmeshpro_ObjectC;
    public GameObject prefab_ObjectC;

    // Constants 
    private readonly string MISSING_TEXT = "Missing";

    async void Start()
    {

        //var tableAnchor = OVRSceneManager.Classification.Table;
        var wallArtAnchor = OVRSceneManager.Classification.WallArt;
        var plantAnchor = OVRSceneManager.Classification.Plant;
             
        _ = new List<OVRAnchor>();

        List<OVRAnchor> anchors = await GetAnchors();
        
        Debug.Log("Anchors main" + anchors.Count);

        await CheckForAnchor(anchors, OVRSceneManager.Classification.Table, textmeshpro_ObjectA, prefab_ObjectA);
        await CheckForAnchor(anchors, wallArtAnchor, textmeshpro_ObjectB, prefab_ObjectB);
        await CheckForAnchor(anchors, plantAnchor, textmeshpro_ObjectC, prefab_ObjectC);

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
    async Task CheckForAnchor(List<OVRAnchor> anchors, string anchorLabel, TMP_Text obj, GameObject prefab)
    {

        Debug.Log("Anchors table 2" + anchors.Count);

        //
        foreach (var roomAnchor in anchors)
        {
 
            if (roomAnchor.TryGetComponent(out OVRSemanticLabels label) && 
                label.Labels.Contains(anchorLabel))
            {
                string activeText = "Active";
                var activeTextColor = Color.green;
                float activeTextSize = 36;

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
                PrefabProps prefabProps = prefab.GetComponent<PrefabProps>();

                float prefabHeight = prefabProps.objHeight;
                float prefabWidth = prefabProps.objWidth;

                // get the height of the meshRenderer for whatever prefab is being passed in
                //float height = prefab.GetComponent<MeshRenderer>().bounds.size.y;
                //float newHeight = prefab.GetComponent<Renderer>().bounds.size.y;

                Debug.Log("Dimensions of the object are, Height: " + prefabHeight 
                    + ", Width: " + prefabWidth);

                if (prefabWidth > anchorWidth && prefabHeight > anchorHeight) {
                    activeText = "The dimensions of the anchor are too small and need to be atleast " + prefabWidth.ToString("0.00") 
                        + "m wide & " + prefabHeight.ToString("0.00")+ "m heigh/deep.";
                    activeTextSize = 12;
                    activeTextColor = Color.yellow;
                } 
                else if (prefabHeight > anchorHeight)
                {
                    activeText = "The " + anchorLabel + " anchor height " + anchorHeight.ToString("0.00") + "m is to small." +
                        " The anchor needs to be at least " + prefabHeight.ToString("0.00") + "m.";
                    activeTextSize = 12;
                    activeTextColor = Color.yellow;
                }
                else if (prefabWidth > anchorWidth)
                {
                    activeText = "The " + anchorLabel + " anchor width " + anchorWidth.ToString("0.00") + "m is to small." +
                        " The anchor needs to be at least " + prefabWidth.ToString("0.00") + "m.";
                    activeTextSize = 12;
                    activeTextColor = Color.yellow;
                }
                obj.text = activeText;
                obj.color = activeTextColor;
                obj.fontSize = activeTextSize;
                return;
            } 
            else
            {
                obj.text = MISSING_TEXT;
                obj.color = Color.red;
            }

        }
        await Task.WhenAll();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
