using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CheckRoomModel : MonoBehaviour
{
    // UI text GameObjects
    public TMP_Text textmeshpro_ObjectA;
    public GameObject prefab_ObjectA;
    public TMP_Text textmeshpro_ObjectB;
    public GameObject prefab_ObjectB;
    public TMP_Text textmeshpro_ObjectC;
    public GameObject prefab_ObjectC;

    // Constants
    private readonly string ACTIVE_TEXT = "Active";
    private readonly string MISSING_TEXT = "Missing";

    async void Start()
    {

        //var objA = textmeshpro_ObjectA;
        //var objB = textmeshpro_ObjectB;
        //var objC = textmeshpro_ObjectC;

        var tableAnchor = OVRSceneManager.Classification.Table;
        var wallArtAnchor = OVRSceneManager.Classification.WallArt;
        var plantAnchor = OVRSceneManager.Classification.Plant;
             
        _ = new List<OVRAnchor>();

        List<OVRAnchor> anchors = await GetAnchors();
        
        Debug.Log("Anchors main" + anchors.Count);

        await CheckForAnchor(anchors, tableAnchor, textmeshpro_ObjectA, prefab_ObjectA);
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
                // Get access to the bounding plane information of the anchor
                roomAnchor.TryGetComponent(out OVRBounded2D bounds);
                var bbox = bounds.BoundingBox;

                // Get the width of the anchor
                float anchorWidth = bbox.width;

                //// creates an instance "test" from the TestProps script and access the TestProps script attached to the prefab (GameObject)
                //TestProps test = prefab.GetComponent<TestProps>();

                obj.text = ACTIVE_TEXT;
                obj.color = Color.green;
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
