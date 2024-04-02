using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class CheckRoomModel : MonoBehaviour
{
    // UI text GameObjects
    public TMP_Text textmeshpro_ObjectA;
    public TMP_Text textmeshpro_ObjectB;
    public TMP_Text textmeshpro_ObjectC;

    // Default Variables
    private string objectA = "Active";
    private string objectB = "Missing";

    async void Start()
    {
        textmeshpro_ObjectA.text = objectB;
        textmeshpro_ObjectA.color = Color.red;
        textmeshpro_ObjectB.text = objectB;
        textmeshpro_ObjectB.color = Color.red;
        textmeshpro_ObjectC.text = objectB;
        textmeshpro_ObjectC.color = Color.red;

        await CheckForTable();
        await CheckForWallArt();
        await CheckForPlant();
    }

    async Task CheckForTable()
    {

        var anchors = new List<OVRAnchor>();
        await OVRAnchor.FetchAnchorsAsync<OVRRoomLayout>(anchors);

        Debug.Log("Anchors " + anchors.Count);

        // get the component to access its data
        var room = anchors.First();

        if (!room.TryGetComponent(out OVRAnchorContainer container))
            return;

        // access all child anchors
        await container.FetchChildrenAsync(anchors);

        Debug.Log("Anchors " + anchors.Count);
        //get all anchors in the room that are a table
        foreach (var roomAnchor in anchors)
        {

            if (roomAnchor.TryGetComponent(out OVRSemanticLabels labels) &&
                labels.Labels.Contains(OVRSceneManager.Classification.Table))
            {
                textmeshpro_ObjectA.text = objectA;
                textmeshpro_ObjectA.color = Color.green;
            }

        }

    }

    async Task CheckForWallArt()
    {
        var anchors = new List<OVRAnchor>();
        await OVRAnchor.FetchAnchorsAsync<OVRRoomLayout>(anchors);
        Debug.Log("Anchors " + anchors.Count);
        // get the component to access its data
        var room = anchors.First();

        if (!room.TryGetComponent(out OVRAnchorContainer container))
            return;

        // access all child anchors
        await container.FetchChildrenAsync(anchors);
        Debug.Log("Anchors " + anchors.Count);
        //get all anchors in the room that are a table
        foreach (var roomAnchor in anchors)
        {

            if (roomAnchor.TryGetComponent(out OVRSemanticLabels labels) &&
                labels.Labels.Contains(OVRSceneManager.Classification.WallArt))
            {
                textmeshpro_ObjectB.text = objectA;
                textmeshpro_ObjectB.color = Color.green;
            }

        }

    }

    async Task CheckForPlant()
    {
        var anchors = new List<OVRAnchor>();
        await OVRAnchor.FetchAnchorsAsync<OVRRoomLayout>(anchors);
        Debug.Log("Anchors " + anchors.Count);
        // get the component to access its data
        var room = anchors.First();

        if (!room.TryGetComponent(out OVRAnchorContainer container))
            return;

        // access all child anchors
        await container.FetchChildrenAsync(anchors);
        Debug.Log("Anchors " + anchors.Count);
        //get all anchors in the room that are a table
        foreach (var roomAnchor in anchors)
        {

            if (roomAnchor.TryGetComponent(out OVRSemanticLabels labels) &&
                labels.Labels.Contains(OVRSceneManager.Classification.Plant))
            {
                textmeshpro_ObjectC.text = objectA;
                textmeshpro_ObjectC.color = Color.green;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
