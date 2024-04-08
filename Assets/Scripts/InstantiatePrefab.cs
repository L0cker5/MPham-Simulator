using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class InstantiatePrefab : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    [SerializeField, Tooltip("Prefab to be placed into the scene, or object in the scene to be moved around.")]
    public GameObject wallArtPrefab;
    public GameObject tablePrefab;
    private Vector3 position;
    private Quaternion rotation;
    private OVRAnchor table;
    private OVRAnchor frame;

    // List of Room Anchors https://developer.oculus.com/documentation/unity/unity-scene-ovranchor/

    // Start is called before the first frame update
    async void Start()
    {
        await SpawnOnWallArt();
        await SpawnOnTable();

    }
    async Task SpawnOnWallArt()
    {
        var anchors = new List<OVRAnchor>();
        var wallArtAnchors = new List<OVRAnchor>();
        await OVRAnchor.FetchAnchorsAsync<OVRRoomLayout>(anchors);

        // get the component to access its data
        var room = anchors.First();
 //       var room = anchors[0];

        if (!room.TryGetComponent(out OVRAnchorContainer container))
            return;

        // access all child anchors
        await container.FetchChildrenAsync(anchors);

        //get all anchors in the room that are a table and add them to the tableAnchors List
        foreach (var roomAnchor in anchors)
        {

            if (roomAnchor.TryGetComponent(out OVRSemanticLabels labels) &&
                labels.Labels.Contains(OVRSceneManager.Classification.WallArt))
            {
                wallArtAnchors.Add(roomAnchor);
            }

        }

        // foreach over all the anchors in the tableAnchors list and use the selected anchor in the list    
        foreach (var wA in wallArtAnchors)
        {
            // Gets the first frame in the List
            frame = wallArtAnchors[0];

            // enable locatable/tracking by checking for the presence of an OVRLocatable component.
            if (!frame.TryGetComponent(out OVRLocatable locatable))
                continue;

            // Get access to the bounding plane information of the anchor
            frame.TryGetComponent(out OVRBounded2D bounds);
            var bbox = bounds.BoundingBox;

            // Get the width & height of the anchor
            float anchorWidth = bbox.width;
            float anchorHeight = bbox.height;
            float anchorHalfHeight = anchorHeight / 2.0f;

            Debug.Log("Wall Art Bounds " + bbox);
            Debug.Log("Wall Art Anchor Height " + anchorHeight);
            Debug.Log("Wall Art Anchor Width " + anchorWidth);

            // creates an instance "test" from the TestProps script and access the TestProps script attached to the prefab (GameObject)
            PrefabProps test = wallArtPrefab.GetComponent<PrefabProps>();

            float objectDepth = 0;
            // assigns the value of test.objDepth to the variable objectDepth
            objectDepth = test.objDepth;

            Debug.Log("Wall Art object Height " + objectDepth);

            // localise the anchor
            locatable.TryGetSceneAnchorPose(out var pose);

            // get half of the depith
            float halfDepth = objectDepth / 2.0f;
            
           Debug.Log("Wall Art object half Depth " + halfDepth);

            // casts the the room anchors position to a Vector3 & moves the positon out on the x(left) axis
            // by half the depth & down to the bottom of the frame  
//            position = (Vector3)pose.Position;
            position = (Vector3)pose.Position + Vector3.left * halfDepth + Vector3.down * anchorHalfHeight;
            // gets the current rotation for the chosen anchor           
            rotation = (Quaternion)pose.Rotation;
            // converts a Vector3 representation of the Quaternion using EulerAngles
            Vector3 newRot = rotation.eulerAngles;
            // Add a value to the relevent x,y,z to ammend the rotation 
//            newRot = new Vector3(newRot.x + 90, newRot.y, newRot.z);
            // rot for Test Objects
            newRot = new Vector3(newRot.x, newRot.y - 90, newRot.z);
            // Convert the Vector3 back to a Quaternion using Quaternion.Euler
            rotation = Quaternion.Euler(newRot);

            Instantiate(wallArtPrefab, position, rotation);

            break;
        }

    }

    async Task SpawnOnTable()
    {
        var anchors = new List<OVRAnchor>();
        var tableAnchors = new List<OVRAnchor>();
        await OVRAnchor.FetchAnchorsAsync<OVRRoomLayout>(anchors);

        // get the component to access its data
        var room = anchors.First();

        if (!room.TryGetComponent(out OVRAnchorContainer container))
            return;

        // access all child anchors
        await container.FetchChildrenAsync(anchors);

        //get all anchors in the room that are a table and add them to the tableAnchors List
        foreach (var roomAnchor in anchors)
        {

            if (roomAnchor.TryGetComponent(out OVRSemanticLabels labels) &&
                labels.Labels.Contains(OVRSceneManager.Classification.Table))
            {
                tableAnchors.Add(roomAnchor);
            }

        }

        // foreach over all the anchors in the tableAnchors list and use the selected anchor in the list    
        foreach (var tA in tableAnchors)
        {
            table = tableAnchors[1];

            // enable locatable/tracking by checking for the presence of an OVRLocatable component.
            if (!table.TryGetComponent(out OVRLocatable locatable))
                continue;

            // Get access to the bounding plane information of the anchor
            table.TryGetComponent(out OVRBounded2D bounds);
            var bbox = bounds.BoundingBox;

            // Get the width & height of the anchor
            float anchorWidth = bbox.width;
            float anchorHeight = bbox.height;

            Debug.Log("Table bounds " + bbox);
            Debug.Log("Table Anchor Height " + anchorHeight);
            Debug.Log("Table Anchor Width " + anchorWidth);

            // creates an instance "test" from the TestProps script and access the TestProps script attached to the prefab (GameObject)
            PrefabProps test = tablePrefab.GetComponent<PrefabProps>();

            // assigns the value of test.objHeight & Width to the variables objectHeight & objectWidth
            float objectHeight = test.objHeight;
            float objectWidth = test.objWidth;

            if (anchorWidth < objectWidth)
            {
                Debug.Log("ERROR - object width " + objectWidth + " is wider that the table " + anchorWidth);
            }
            else
            {
                Debug.Log("Table object height " + objectHeight);

                // localise the anchor
                locatable.TryGetSceneAnchorPose(out var pose);

                // get half of the height
                float halfHeight = objectHeight / 2.0f;

                Debug.Log("Table object half height " + halfHeight);

                // casts the the room anchors position to a Vector3 and moves the positon up on the y axis by half the height  
                position = (Vector3)pose.Position;
                //            position = (Vector3)pose.Position + Vector3.up * halfHeight;
                // gets the current rotation for the chosen anchor           
                rotation = (Quaternion)pose.Rotation;
                // converts a Vector3 representation of the Quaternion using EulerAngles
                Vector3 newRot = rotation.eulerAngles;
                // Add a value to the relevent x,y,z to ammend the rotation 
                //            newRot = new Vector3(newRot.x + 90, newRot.y, newRot.z);
                // rot for Test Objects
                newRot = new Vector3(newRot.x + 90, newRot.y - 90, newRot.z);
                // Convert the Vector3 back to a Quaternion using Quaternion.Euler
                rotation = Quaternion.Euler(newRot);

                Instantiate(tablePrefab, position, rotation);
                //            Debug.Log("height " + newHeight);
                break;

            }

        }


    }

    // Update is called once per frame
    void Update()
    {

    }

}
